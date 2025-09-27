import newman from 'newman';
import { readdir } from 'fs/promises';
import path from 'path';
import type { NewmanRunSummary } from 'newman';

// Set the BASE_URL environment variable
process.env.BASE_URL = "http://localhost:5141";

console.log(`Setting BASE_URL to: ${process.env.BASE_URL}`);

async function runPostmanCollections() {
  const collectionsDir = './collections';
  
  try {
    // Read all files in the collections directory
    const files = await readdir(collectionsDir);
    const collectionFiles = files.filter(file => file.endsWith('.postman_collection.json'));
    
    console.log(`Found ${collectionFiles.length} Postman collection(s) to run:`);
    collectionFiles.forEach(file => console.log(`  - ${file}`));
    
    // Run each collection
    for (const collectionFile of collectionFiles) {
      const collectionPath = path.join(collectionsDir, collectionFile);
      console.log(`\n🧪 Running collection: ${collectionFile}`);
      
      await new Promise<NewmanRunSummary>((resolve, reject) => {
        newman.run({
          collection: collectionPath,
          environment: {
            values: [
              {
                key: 'BASE_URL',
                value: process.env.BASE_URL!
              }
            ]
          },
          reporters: ['cli'],
          bail: true // Stop on first failure
        }, (err: Error | null, summary: NewmanRunSummary) => {
          if (err) {
            console.error(`❌ Collection ${collectionFile} failed:`, err);
            reject(err);
          } else {
            const totalTests = summary.run.stats.tests?.total || 0;
            const failedTests = summary.run.stats.tests?.failed || 0;
            
            if (failedTests > 0) {
              console.error(`❌ Collection ${collectionFile} completed with ${failedTests}/${totalTests} test failures`);
              reject(new Error(`${failedTests} test(s) failed in ${collectionFile}`));
            } else {
              console.log(`✅ Collection ${collectionFile} completed successfully (${totalTests} tests passed)`);
              resolve(summary);
            }
          }
        });
      });
    }
    
    console.log('\n🎉 All collections completed successfully!');
    
  } catch (error) {
    console.error('\n💥 Error running collections:', error);
    process.exit(1);
  }
}

// Run the collections
runPostmanCollections();
