
public class Game
{
    public const uint width = 1280;
    public const uint height = 720;
    private const string title = "Example project";
    private RenderWindow window;
    private readonly VideoMode mode = new(width, height);
    private readonly Font font = new("./Resources/Fonts/Arial.ttf");

    // fps counter stuff
    private int framesRendered;
    private int fps;
    private Text fpsText;
    private DateTime lastTime;
    private Clock deltaClock = new();

    public Game()
    {
        window = new RenderWindow(mode, title, Styles.Titlebar | Styles.Close);

        window.SetVerticalSyncEnabled(true);
        window.Closed += (_, _) => window.Close();
        window.RequestFocus();
        
        fpsText = new Text((fps).ToString(), font, 30);
    }

    public void Run()
    {
        GuiImpl.Init(window);
        while (window.IsOpen)
        {
            HandleEvents();
            Update();
            Draw();
        }
    }

    private void HandleEvents()
    {
        window.DispatchEvents();
    }

    private void Update()
    {
        GuiImpl.Update(window, deltaClock.Restart().AsSeconds());
    }
    
    private void Draw()
    {
        framesRendered++;
        
        window.Clear(Color.Black);

        if ((DateTime.Now - lastTime).TotalSeconds >= 1)
        {
            // one second has elapsed 
            fps = framesRendered;                     
            framesRendered = 0;            
            lastTime = DateTime.Now;
        }
        
        ImGui.ShowDemoWindow();

        GuiImpl.Render(window);
        fpsText.DisplayedString = fps.ToString();
        window.Draw(fpsText);
        
        window.Display();
    }
}