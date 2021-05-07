using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;
using System.Linq;
using System.Collections.Generic;


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
            for (int i = 0; i < items.Count; i++)
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
                if (items[i] != null && (items[i].GetType() == typeof(Sword)|| items[i].GetType() == typeof(Axe)))
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
            /*Item[] memory = new Item[items.Count];
            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = items[i];
            }
            items.Clear();
            
            foreach (Item it in memory)
            {
                if (it != null && it.GetType() == typeof(Heart))
                {
                    items.Add(it);
                }
            }
            foreach (Item it in memory)
            {
                if (it != null && (it.GetType() == typeof(Sword) || it.GetType() == typeof(Axe)))
                {
                    items.Add(it);
                }
            }
            foreach (Item it in memory)
            {
                if (it != null && it.GetType() == typeof(Bomb))
                {
                    items.Add(it);
                }
            }
            foreach (Item it in memory)
            {
                if (it != null && it.GetType() == typeof(Coin))
                {
                    items.Add(it);
                }
            }
            foreach (Item it in memory)
            {
                if (it != null && (it.GetType() == typeof(Blinky)|| it.GetType() == typeof(Blinky)))
                {
                    items.Add(it);
                }
            }*/
            items.OrderBy(item => item.order);
        }

        private void ReverseItems()
        {
            items.Reverse();
        }

        public void MousePressed(object sender, MouseButtonEventArgs e)
        {
            if (true)
            {
                int mouseColumn = (int)Math.Floor((double)e.X / (double)SlotWidth);
                int mouseRow = (int)Math.Floor((double)e.Y / (double)SlotHeight);
                int itemIndexClicked = mouseRow * numColumns + mouseColumn;

                for (int i = 0; i < items.Count; ++i)
                {
                    if (items[i] != null)
                    {
                        if (itemIndexClicked == i)
                        {
                            if (items[i].GetType() == typeof(Bomb))
                            {
                                IsBomb(itemIndexClicked, mouseColumn, mouseRow);
                            }

                            items[i] = null;
                        }
                    }
                }
            }
        }

        public void IsBomb(int indexBomba, int yBomba, int xBomba)
        {
            Item[,] itemArray = new Item[numRows, numColumns];
            int index = 0;

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    try
                    {
                        itemArray[i, j] = items[index];
                        index++;
                    }
                    catch (Exception) { }
                }
            }

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    if (Math.Abs(i - xBomba) < 2 && Math.Abs(j - yBomba) < 2)
                    {
                        itemArray[i, j] = null;
                    }
                }
            }

            items.Clear();

            foreach (Item it in itemArray)
            {
                items.Add(it);
            }
        }
    }
}
