namespace CCharpPlayground
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FileManager
    {
        public static void Download()
        {
            string chunkDirectory = "/path/to/chunks"; // Replace with your chunk directory path
            int totalNumberOfChunks = GetTotalNumberOfChunks(); // Replace with the actual number of chunks

            List<byte[]> chunks = new List<byte[]>();

            for (int chunkNumber = 0; chunkNumber < totalNumberOfChunks; chunkNumber++)
            {
                string chunkFilePath = Path.Combine(chunkDirectory, $"chunk_{chunkNumber}.dat");

                if (File.Exists(chunkFilePath))
                {
                    byte[] chunkData = File.ReadAllBytes(chunkFilePath);
                    chunks.Add(chunkData);
                }
                else
                {
                    Console.WriteLine($"Chunk {chunkNumber} is missing.");
                    // Handle missing chunk error or perform a retry logic
                }
            }

            byte[] reconstructedFileData = ConcatenateChunks(chunks);

            string reconstructedFilePath = "/path/to/reconstructed_file.ext"; // Replace with your desired file path
            File.WriteAllBytes(reconstructedFilePath, reconstructedFileData);

            Console.WriteLine("File reconstruction complete.");
        }

        static int GetTotalNumberOfChunks()
        {
            // Implement logic to determine the total number of chunks, e.g., from metadata or user input
            return 10; // Replace with the actual number of chunks
        }

        static byte[] ConcatenateChunks(List<byte[]> chunks)
        {
            int totalSize = chunks.Sum(chunk => chunk.Length);
            byte[] reconstructedData = new byte[totalSize];
            int offset = 0;

            foreach (byte[] chunk in chunks)
            {
                Buffer.BlockCopy(chunk, 0, reconstructedData, offset, chunk.Length);
                offset += chunk.Length;
            }

            return reconstructedData;
        }

        static void Upload()
        {
            string inputFile = "/path/to/original_file.ext"; // Replace with your source file path
            string outputDirectory = "/path/to/chunks"; // Replace with the output directory for chunks
            int chunkSizeBytes = 1024 * 1024; // 1MB chunk size (adjust as needed)

            CreateChunks(inputFile, outputDirectory, chunkSizeBytes);

            Console.WriteLine("Chunk creation complete.");
        }

        static void CreateChunks(string inputFile, string outputDirectory, int chunkSize)
        {
            // Check if the output directory exists; create it if it doesn't
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            byte[] buffer = new byte[chunkSize];
            int bytesRead;
            int chunkNumber = 0;

            using (FileStream fileStream = File.OpenRead(inputFile))
            {
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string chunkFilePath = Path.Combine(outputDirectory, $"chunk_{chunkNumber}.dat");
                    using (FileStream chunkFileStream = File.Create(chunkFilePath))
                    {
                        chunkFileStream.Write(buffer, 0, bytesRead);
                    }
                    chunkNumber++;
                }
            }
        }
    }
}
