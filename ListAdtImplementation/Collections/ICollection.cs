namespace ListAdtImplementation.Collections
{
    public interface ICollection<Obj>
    {
        int Capacity { get; }
        int Count { get; }

        void Add(Obj obj);
        void Add(params Obj[] objs);
        void Clear();
        bool Empty();
    }
}
