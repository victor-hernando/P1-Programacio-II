﻿using SFML.Graphics;
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
            switch (rnd.Next(7))
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
                case 6:
                    return new Heart();
                default:
                    return null;
            }
        }


        private void RemoveLastItem()
        {
            int index = 0;
            foreach (Item it in items)
            {
                if (index == items.Count - 1)
                {
                    items.Remove(it);
                    break;
                }
                index++;
            }
        }

        private void NullAllCoins()
        {
            for(int i= 0; i < items.Count; i++)
            {
                if (items[i] != null && items[i].GetType() == typeof(Coin))
                {
                    items[i] = null;
                }
            }
        }

        private void RemoveNullSlots()
        {
            bool finished=false;
            foreach (Item it in items)
            {
                if (it == null)
                {
                    items.Remove(it);
                    finished = false;
                    break;
                }
                else finished = true;
            }
            if(finished!=true)RemoveNullSlots();
        }

        private void RemoveAllItems()
        {
            items.Clear();
        }


        private void NullAllWeapons()
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] != null && items[i].GetType() == typeof(Weapon))
                {
                    items[i] = null;
                }
            }
        }


        private bool HasNullSlot()
        {
            foreach (Item it in items)
            {
                if(it==null)return true;
            }
            return false;
        }

        private int GetFirstNullSlot()
        {
            int count=0;
            foreach (Item it in items)
            {
                if (it == null) return count;
                count++;
            }
            return 0;
        }

        private void AddItemAtIndex(Item item, int index)
        {
            items.RemoveAt(index);
            items.Insert(index, item);
        }

        private void AddItemAtEnd(Item item)
        {
            items.Add(item);
        }


        private void OrderItems()
        {
            //items.
        }

        private void ReverseItems()
        {
            items.Reverse();
        }

        public void MousePressed(object sender, MouseButtonEventArgs e)
        {
            if(true)
            {
                float mx, my;
                mx = e.X;
                my = e.Y;

                for (int i = 0; i < items.Count; ++i)
                {
                    if(items[i] != null)
                    {
                        if ((mx > items[i].Position.X - SlotWidth / 2.0f && mx < items[i].Position.X + SlotWidth / 2.0f) &&
                        (my > items[i].Position.Y - SlotHeight / 2.0f && my < items[i].Position.Y + SlotHeight / 2.0f))
                        {                            
                            if(items[i].GetType() == typeof(Bomb))
                            {
                                IsBomb(items[i]);
                            }

                            items[i] = null;
                        }
                    }                          
                }               
            }
        }

        public void IsBomb(Item bomb)
        {
            for (int j = 0; j < items.Count; ++j)
            {
                if (items[j] != null)
                {
                    if ((items[j].Position.X + SlotWidth == bomb.Position.X && items[j].Position.Y == bomb.Position.Y) ||
                    (items[j].Position.X - SlotWidth == bomb.Position.X && items[j].Position.Y == bomb.Position.Y) ||
                    (items[j].Position.Y - SlotHeight == bomb.Position.Y && items[j].Position.X == bomb.Position.X) ||
                    (items[j].Position.Y + SlotHeight == bomb.Position.Y && items[j].Position.X == bomb.Position.X) || 
                    (items[j].Position.Y + SlotHeight == bomb.Position.Y && items[j].Position.X + SlotWidth == bomb.Position.X && items[j].Position.X + SlotWidth == bomb.Position.X
                    && items[j].Position.Y + SlotHeight == bomb.Position.Y) ||
                    (items[j].Position.Y - SlotHeight == bomb.Position.Y && items[j].Position.X + SlotWidth == bomb.Position.X && items[j].Position.X + SlotWidth == bomb.Position.X
                    && items[j].Position.Y - SlotHeight == bomb.Position.Y) ||
                    (items[j].Position.Y + SlotHeight == bomb.Position.Y && items[j].Position.X - SlotWidth == bomb.Position.X && items[j].Position.X - SlotWidth == bomb.Position.X
                    && items[j].Position.Y + SlotHeight == bomb.Position.Y) ||
                    (items[j].Position.Y - SlotHeight == bomb.Position.Y && items[j].Position.X - SlotWidth == bomb.Position.X && items[j].Position.X - SlotWidth == bomb.Position.X
                    && items[j].Position.Y - SlotHeight == bomb.Position.Y))
                    {
                        items[j] = null;
                    }
                }
            }
        }
    }
}
