using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Treetown
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;

        Texture2D blueKnightLeft;
        Texture2D blueKnightRight;
        Texture2D arrowLeft;
        Texture2D arrowRight;
        Texture2D grass;
        Texture2D stone;

        Arrow testArrow;


        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            
            graphics.PreferredBackBufferWidth = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width * 0.5);
            graphics.PreferredBackBufferHeight = (int)(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height * 0.5);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            player = new Player(new Vector2(49, 64), new Vector2(0, 0));
            testArrow = new Arrow(64, 20);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            grass = Content.Load<Texture2D>("map/grass");
            stone = Content.Load<Texture2D>("map/stone");
            blueKnightLeft = Content.Load<Texture2D>("objects/blue_knight_left");
            blueKnightRight = Content.Load<Texture2D>("objects/blue_knight_right");
            arrowRight = Content.Load<Texture2D>("objects/arrow_right");
            arrowLeft = Content.Load<Texture2D>("objects/arrow_left");

            testArrow.setPosition(0, 0);
            testArrow.setDirection(true, arrowRight);

            player.loadSprite(blueKnightRight, blueKnightLeft);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Vector2 newPosition = new Vector2(player.getPosition().X + 2, player.getPosition().Y);
                player.updatePosition(newPosition);
                player.setRight();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Vector2 newPosition = new Vector2(player.getPosition().X - 2, player.getPosition().Y);
                player.updatePosition(newPosition);
                player.setLeft();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Vector2 newPosition = new Vector2(player.getPosition().X, player.getPosition().Y - 2);
                player.updatePosition(newPosition);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Vector2 newPosition = new Vector2(player.getPosition().X, player.getPosition().Y + 2);
                player.updatePosition(newPosition);
            }


            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                testArrow.setPosition((int)player.getPosition().X, (int)player.getPosition().Y);
            }


            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(grass, new Rectangle(0, 0, 128, 128), Color.White);



            testArrow.drawArrow(spriteBatch);


            player.drawSprite(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
