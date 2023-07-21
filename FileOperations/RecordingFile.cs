namespace FileWriter
{
    public class RecordingFile
    {
        public void CreateFile(string filePath, List<string> result)
        {
            File.WriteAllLines(filePath, result);
        }
        public string CreateNewFileFullPath(string path)
        {
            string filename = Path.GetFileName(path);
            string currentDirectory = Path.GetDirectoryName(path);
            string fullFilePath = Path.GetFullPath(currentDirectory);
            string[] filetxt = filename.Split(".");
            string preaparename = filetxt[0];
            preaparename += ".result." + filetxt[1];
            fullFilePath += "/" + preaparename;
            return fullFilePath;
        }
    }
}
