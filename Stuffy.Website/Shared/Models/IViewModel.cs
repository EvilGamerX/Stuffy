namespace Stuffy.Website.Shared.Models
{
    public interface IViewModel<T> where T : class
    {
        public T ToEntity();
    }
}
