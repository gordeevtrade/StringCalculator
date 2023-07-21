namespace FileReader
{
    public class ReadingFile
    {
        public bool IsFileExist(string filePath)
        {
            bool checker = File.Exists(filePath);
            return checker;
        }

        public List<String> ReturnElementsFromFile(string filePath)
        {
            List<String> fileElements = new List<String>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string fileLine = String.Empty;
                while ((fileLine = reader.ReadLine()) != null)
                {
                    fileElements.Add(fileLine);
                }
                return fileElements;
            }
        }
    }
}
