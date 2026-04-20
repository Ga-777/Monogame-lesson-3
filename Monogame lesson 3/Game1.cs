using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_lesson_3
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Vector2 tribbleGreySpeed;
        Rectangle window, greyTribblerect;
        Texture2D tribbleGreyTexture;
        SoundEffect tribbleCoo;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            greyTribblerect = new Rectangle(300, 10, 100, 100);
            tribbleGreySpeed = new Vector2(3, 3);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
                tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
                tribbleCoo = Content.Load<SoundEffect>("tribble_Coo");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            greyTribblerect.X += (int)tribbleGreySpeed.X;
            greyTribblerect.Y += (int)tribbleGreySpeed.Y;
            if (greyTribblerect.Left < window.Left || greyTribblerect.Right > window.Right)
            {
                tribbleGreySpeed.X *= -1;
                tribbleCoo.Play();
            }
            else if (greyTribblerect.Top < window.Top || greyTribblerect.Bottom > window.Bottom)
            {
                tribbleGreySpeed.Y *= -1;
                tribbleCoo.Play();
            }
           
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(tribbleGreyTexture, greyTribblerect, Color.White);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
