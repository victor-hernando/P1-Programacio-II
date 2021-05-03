using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using SFML.System;


namespace TcGame
{
    public class Grid : Drawable
    {
        private Random rnd = new Random();
        private LineDrawer lines;

        private const int numColumns = 4;

        private const int numRows = 3;

        private List<Item> items;

        private Texture backgroundTexture;
        private Sprite backgroundSprite;

        public float SlotWidth
        {
            get { return P1Game.ScreenSize.X / (float)numColumns; }
        }

        public float SlotHeight
        {
            get { return P1Game.ScreenSize.Y / (float)numRows; }
        }

        public int MaxItems
        {
            get { return numColumns * numRows; }
        }

        public void Init()
        {
            backgroundTexture = new Texture("Data/Textures/Background.jpg");
            backgroundSprite = new Sprite(backgroundTexture);

            items = new List<Item>();
            FillGridLines();
        }

        public void DeInit()
        {
            lines.DeInit();
        }

        public void HandleKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.A)
            {
                if (HasNullSlot())
                {
                    AddItemAtIndex(NewRandomItem(), GetFirstNullSlot());
                }
                else
                {
                    AddItemAtEnd(NewRandomItem());
                }
            }
            else if (e.Code == Keyboard.Key.R)
            {
                RemoveLastItem();
            }
            else if (e.Code == Keyboard.Key.N)
            {
                NullAllCoins();
            }
            else if (e.Code == Keyboard.Key.V)
            {
                ReverseItems();
            }
            else if (e.Code == Keyboard.Key.S)
            {
                RemoveNullSlots();
            }
            else if (e.Code == Keyboard.Key.M)
            {
                RemoveAllItems();
            }
            else if (e.Code == Keyboard.Key.K)
            {
                NullAllWeapons();
            }
            else if (e.Code == Keyboard.Key.O)
            {
                OrderItems();
            }
        }

        private void FillGridLines()
        {
            lines = new LineDrawer(numColumns + numRows + 2);
            lines.Init();

            for (int i = 0; i <= numColumns; ++i)
            {
                lines.AddLine(new Vector2f(i * SlotWidth, 0.0f), new Vector2f(i * SlotWidth, P1Game.ScreenSize.Y), new Color(0, 0, 0, 150), 2.0f);
            }

            for (int i = 0; i <= numRows; ++i)
            {
                lines.AddLine(new Vector2f(0.0f, i * SlotHeight), new Vector2f(P1Game.ScreenSize.X, i * SlotHeight), new Color(0, 0, 0, 150), 2.0f);
            }
        }

        public void Update(float dt)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                int row = i / numColumns;
                int column = i % numColumns;

                Vector2f position = new Vector2f(SlotWidth / 2.0f + SlotWidth * column, SlotHeight / 2.0f + SlotHeight * row);
                Item item = items[i];
                if (item != null)
                {
                    item.Position = position;
                }
            }
        }

        public void Draw(RenderTarget rt, RenderStates rs)
        {
            rt.Draw(backgroundSprite, rs);
            rt.Draw(lines, rs);

            foreach (Item item in items)
            {
                if (item != null)
                {
                    rt.Draw(item, rs);
                }
            }
        }

        private Item NewRandomItem()
        {
            switch (rnd.Next(6))
            {
                case 0:
                    return new Blinky();
                case 1:
                    return new Clyde();
                case 2:
                    return new Axe();
                case 3:
                    return new Bomb();
                case 4:
                    return new Coin();
                case 5:
                    return new Sword();
                default:
                    return null;
            }
        }


        private void RemoveLastItem()
        {

        }

        private void NullAllCoins()
        {

        }

        private void RemoveNullSlots()
        {

        }

        private void RemoveAllItems()
        {

        }


        private void NullAllWeapons()
        {

        }


        private bool HasNullSlot()
        {

            return false;
        }

        private int GetFirstNullSlot()
        {

            return 0;
        }

        private void AddItemAtIndex(Item item, int index)
        {

        }

        private void AddItemAtEnd(Item item)
        {
            items.Add(item);
        }


        private void OrderItems()
        {

        }

        private void ReverseItems()
        {

        }

        public void MousePressed(object sender, MouseButtonEventArgs e)
        {
            if(Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                float mx, my;
                Vector2i mousePosition = Mouse.GetPosition();
                mx = mousePosition.X;
                my = mousePosition.Y;

                for(int i = 0; i <= numRows; i++)
                {
                    for(int j = 0; j <= numColumns; j++)
                    {
                        if(mx == i && my == j)
                        {
                            
                        }
                    }
                }
            }
        }
    }
}
