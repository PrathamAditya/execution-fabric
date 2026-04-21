using Tools.Interface;


namespace Tools
{
    public class GetDateTool: ITool
    {
        public string Name => "get_date";
        public  string Description => "Get the current date and time.";
        public string Execute(string input)
        {
            return DateTime.Now.ToString();
        }
    }
}
