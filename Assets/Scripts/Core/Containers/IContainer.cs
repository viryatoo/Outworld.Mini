namespace OutworldMini.Core.Containers
{
    public interface IContainer
    {
        TType GetSingle<TType>();
        void RegisterSingle<TType>(TType obj);
    }
}