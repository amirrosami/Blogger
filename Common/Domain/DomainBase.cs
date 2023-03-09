namespace Common
{
    public class DomainBase<T>
    {
        public T Id { get;} // readonly property (identity(1,1)) 
        public DateTime CreationDate { get; set; }
        public DomainBase()
        {
            CreationDate = DateTime.Now;
        }
    }
}