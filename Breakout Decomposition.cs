/*
DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT DRAFT 

Breakout Decomposition 
Andrich, Daniël & Wesley

Andrich: Bricks
Wesley: Powerups
Daniël: Multiplayer

Bricks:
Bricks have different variants: Clay, Silver, Gold.
Bricks can be damaged/broken by being hit by the ball.
Clay bricks break after 1 hit. Silver bricks break after 3 hits. Gold bricks break after 5 hits.
The more hits it takes to break a brick the more points you gain after breaking one.
These bricks sometimes drop a powerup after being broken.]
Clay bricks: Static, starts with a random color.
Silver bricks: Moves horizontally.
Gold bricks: Static, drops horizontally moving bombs in intervals.

UML Bricks Draft: 

class Brick:
    int durability; 
    Vector2 position;
    int points;

class Clay: Brick
    Color color;

class Silver: Brick
    Vector2 moveDirection;

class Gold: Brick
    float spawnTime;

Methods:
    public virtual void Initialize();
    public virtual void Deactivate();
    public virtual void DropPowerUp();

Powerups:
In Breakout there are multiple powerups: Laser, Enlarge, Catch, Slow, Break, Disruption & Player (From Arkanoid Game)
When breaking a brick there is a x amount of chanche a powerup will spawn. When collecting the powerup. One of the powerups will happen for an x ammount of time.
Some powerups are stackable (with a max size).

Powerups:
    Laser: Increases the projectile count.
    Enlarge: Increases the size of the paddle.
    Catch: Allows the paddle to catch and hold the ball temporarily.
    Slow: Reduces the speed of the balls.
    Break: Instantly destroys a certain number of bricks upon activation.
    Disruption: Splits the ball into multiple balls.
    Player: Gives the player an extra life.

UML PowerUp Draft:

class PowerUp:
    Vector2 position;
    float duration;
    bool stackable;

Methods:
    protected virtual void Update();
    public virtual void Activate();
    protected virtual void Deactivate();

class Enlarge : PowerUp
    float enlargementFactor;

class Slow : PowerUp
    float speedReduction;

class Disruption : Powerups:
    int ballMultiplier;

Local Multiplayer:
In multiplayer for breakout each player controls an instance of a paddle.
The maximum amount of players is 3.
Players can't move through eachother but are not confined to a screen space
When another input device is detected a new player object is added to a Multiplayer class and instanced .
When a device disconnects the respective player are removed from the class and removed ffrom the scene
When a paddle touches a powerup the corresponding player is given the powerup.

UML Draft:

Class MultiplayerHandler:
    Dictionary<Device, Player> players;
    int maxPlayerCount = 3;
    
Methods:
    private void AddPlayer();
    private void RemovePlayer();
    public void OnNewDevice(Device someDevice);
    public void OnDeviceDisconnect(Device someDevice);
