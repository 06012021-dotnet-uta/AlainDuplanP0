namespace DelegateSimple{
    
    public class DelegateSimple
    {
        public delegate void SimpleDelegate();
        public SimpleDelegate mySimpleDelegate;

        public delegate int NotSimpleDelegate(string message);

        public NotSimpleDelegate myNotSimpleDelegate;

    }
}