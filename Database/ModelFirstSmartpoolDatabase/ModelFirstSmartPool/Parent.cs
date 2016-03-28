namespace ModelFirstSmartPool
{
    public class Parent
    {
        public Control Control { get; set; }
    }

    public abstract class Control
    {
        public abstract void Add();
    }

    class UserControl : Control
    {
        public override void Add()
        {
            
        }
    }
}