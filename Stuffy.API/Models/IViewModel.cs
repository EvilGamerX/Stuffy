namespace Stuffy.API.Models
{
    public interface IViewModel<T> where T : class
    {
        public T ToEntity();
    }
}
