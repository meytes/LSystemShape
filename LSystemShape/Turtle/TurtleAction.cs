namespace Meytes.WPF.LSystemShape
{
    public enum TurtleAction : byte
    {
        Nothing, //Ничего не делать
        Turn,    //Повернуться на значение Value
        Forward, //Двигаться вперёд на Value
        Save,    //Сохранить текущую позицию черепашки в стек
        Restore  //Восстановить текущую позицию черепашки из стека
    }
}