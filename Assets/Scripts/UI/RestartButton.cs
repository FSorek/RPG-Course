using UnityEngine.UI;

public class RestartButton : Button
{
    private static RestartButton instance;
    public static bool Pressed => instance != null && instance.IsPressed();

    protected override void OnEnable()
    {
        instance = this;
        base.OnEnable();
    }
}
