using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading;

namespace Monogame_lesson_3
{
    enum Screen
    {
        Intro,
        TribbleYard,
        EndScreen,
        openDoorEnding,
        BlackHoleEnding

    }


    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        Screen screen;
        Vector2 tribbleGreySpeed, tribbleBrownSpeed, tribbleOrangeSpeed, tribbleCreamSpeed;
        Rectangle window, greyTribblerect, tribbleBrownrect, tribbleCreamrect,tribbleOrangerect;
        Texture2D tribbleGreyTexture, tribbleBrownTexture, tribbleCreamTexture, tribbleOrangeTexture, living_roomBackground, bedroomTexture, bathroomTexture, kitchenTexture, introTexture, blackHoleTexture, openDoorTexture;
        SoundEffect tribbleCoo, openingDoor;
        MouseState mouseState;
        Random locate = new Random(), room = new Random();
        int roomNumber, doorsOpened = 0;
        SpriteFont text;
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
            screen = Screen.Intro;
            greyTribblerect = new Rectangle(300, 100, 100, 100);
            tribbleGreySpeed = new Vector2(4, 2);
            tribbleBrownrect = new Rectangle(locate.Next(0, 700), locate.Next(0, 500), 100, 100);
            tribbleBrownSpeed = new Vector2(2, 0);
            tribbleCreamrect = new Rectangle(locate.Next(0, 700), locate.Next(0, 500), 100, 100);
            tribbleCreamSpeed = new Vector2(3, 1);
            tribbleOrangerect = new Rectangle(locate.Next(0, 700), locate.Next(0, 500), 100, 100);
            tribbleOrangeSpeed = new Vector2(0, 3);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
                tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
                tribbleCoo = Content.Load<SoundEffect>("tribble_Coo");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            living_roomBackground = Content.Load<Texture2D>("living_room");
            bathroomTexture = Content.Load<Texture2D>("bathroom");
            bedroomTexture = Content.Load<Texture2D>("bedroom");
            kitchenTexture = Content.Load<Texture2D>("kitchen");
            openingDoor = Content.Load<SoundEffect>("door_open");
            introTexture = Content.Load<Texture2D>("intro");
            blackHoleTexture = Content.Load<Texture2D>("blackhole");
            text = Content.Load<SpriteFont>("text");
            openDoorTexture = Content.Load<Texture2D>("opendoor");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            
            
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            MouseState mouseState = Mouse.GetState();

            // TODO: Add your update logic here
            if (screen == Screen.Intro)
            {
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    screen = Screen.TribbleYard;
                }
            }
            else if (tribbleOrangeSpeed.Y > 900 && screen == Screen.TribbleYard)
            {
                screen = Screen.BlackHoleEnding;
                if (screen == Screen.BlackHoleEnding)
                {
                    
                }
            }
            else if (doorsOpened > 8 && screen == Screen.TribbleYard)
            {
                screen = Screen.openDoorEnding;
            }
            else if (screen == Screen.TribbleYard)
            {
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

                tribbleBrownrect.X += (int)tribbleBrownSpeed.X;
                tribbleBrownrect.Y += (int)tribbleBrownSpeed.Y;
                if (tribbleBrownrect.Right > window.Right - -100)
                {
                    tribbleBrownrect.X = (-100);
                    roomNumber = room.Next(1, 4);
                    openingDoor.Play();
                    tribbleCoo.Play();
                    doorsOpened++;

                }
                else if (tribbleBrownrect.Top < window.Top || tribbleBrownrect.Bottom > window.Bottom)
                {
                    tribbleBrownSpeed.Y *= -1;
                    tribbleCoo.Play();
                }

                tribbleCreamrect.X += (int)tribbleCreamSpeed.X;
                tribbleCreamrect.Y += (int)tribbleCreamSpeed.Y;
                if (tribbleCreamrect.Left < window.Left || tribbleCreamrect.Right > window.Right)
                {
                    tribbleCreamrect.X = locate.Next(0, 700);
                    tribbleCreamSpeed.X *= -1;
                    tribbleCoo.Play();
                }
                else if (tribbleCreamrect.Top < window.Top || tribbleCreamrect.Bottom > window.Bottom)
                {
                    tribbleCreamrect.Y = locate.Next(0, 500);
                    tribbleCreamSpeed.Y *= -1;
                    tribbleCoo.Play();
                }
                tribbleOrangerect.X += (int)tribbleOrangeSpeed.X;
                tribbleOrangerect.Y += (int)tribbleOrangeSpeed.Y;
                if (tribbleOrangerect.Left < window.Left || tribbleOrangerect.Right > window.Right)
                {
                    tribbleOrangeSpeed.X *= -1;
                    tribbleCoo.Play();
                }
                else if (tribbleOrangerect.Bottom > window.Bottom - -100)
                {

                    tribbleOrangerect.Y = -100;
                    tribbleOrangeSpeed.Y++;
                    tribbleCoo.Play();
                    if (tribbleOrangeSpeed.Y > 1000)
                    {
                        tribbleOrangeSpeed.Y = 1;

                    }
                }
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (greyTribblerect.Contains(mouseState.Position))
                    {

                    }
                    else if (tribbleBrownrect.Contains(mouseState.Position))
                    {
                        tribbleBrownrect.X = -10;


                    }
                    else if (tribbleCreamrect.Contains(mouseState.Position))
                    {
                        tribbleCreamrect.X = locate.Next(0, 700);
                        tribbleCreamrect.Y = locate.Next(0, 500);

                    }
                    else if (tribbleOrangerect.Contains(mouseState.Position))
                    {
                        tribbleOrangeSpeed.Y = 2;
                    }
                }
                if (tribbleCreamrect == tribbleBrownrect)
                {

                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, window, Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                if (roomNumber == 1)
                {
                    _spriteBatch.Draw(living_roomBackground, window, Color.White);
                }
                else if (roomNumber == 2)
                {
                    _spriteBatch.Draw(bathroomTexture, window, Color.White);
                }
                else if (roomNumber == 3)
                {
                    _spriteBatch.Draw(bedroomTexture, window, Color.White);
                }
                else
                {
                    _spriteBatch.Draw(kitchenTexture, window, Color.White);
                }
                _spriteBatch.Draw(tribbleGreyTexture, greyTribblerect, Color.White);
                _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownrect, Color.White);
                _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamrect, Color.White);
                _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangerect, Color.White);

            }
            else if (screen == Screen.BlackHoleEnding)
            {
                _spriteBatch.Draw(blackHoleTexture, window, Color.White);
                _spriteBatch.DrawString(text, "The Orange tribble has gone to fast, and made a blackhole that sucked everything up!", new Vector2(10, 10), Color.Yellow);
                _spriteBatch.DrawString(text, "The End", new Vector2(10, 50), Color.Yellow);
            }
            else if (screen == Screen.openDoorEnding)
            {
                _spriteBatch.Draw(openDoorTexture, window, Color.White);
                _spriteBatch.DrawString(text, "The tribbles have opened too many doors, and have escaped into the world!", new Vector2(10, 10), Color.Yellow);
                _spriteBatch.DrawString(text, "The End", new Vector2(10, 50), Color.Yellow);
            }


            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
