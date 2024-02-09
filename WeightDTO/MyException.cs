namespace WeightDTO
{
    public class MyException : Exception
    {
        public int Status { get; set; }
        public string NameTable { get; set; }
        public MyException(int status, string nameTable, string message) : base(message)
        {
            this.Status = status;
            this.NameTable = nameTable;
        }
    }
}