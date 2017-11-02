using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace clever_ant
{
    public partial class Form1 : Form
    {
        int MATRIX_SIZE = 30;
        int startX = 1, startY = 1;
        const int RANDOM_GENERATE = 15;

        int one_cell;
        Graphics g = null;
        Pen frame_line = null;
        System.Timers.Timer timer = new System.Timers.Timer(200);
        bool timerOn = false;

        int[,] 
            pheromone = null,
            ant_near = new int[8,2];
        bool[,] eat = null;
        int[] ant = new int[2] { 1, 1};
        bool loaded = false,
            goHome = false;
        int eatCount = 0;

        bool setHome = false;

        private void button_load_Click(object sender, EventArgs e)
        {
            try
            {
                MATRIX_SIZE = Convert.ToInt32(textBox_matrixSize.Text);
            }
            catch
            {
                loaded = false;
                ErrorMsg("Неверная размерность матрицы");
                return;
            }
            if (MATRIX_SIZE > 99 || MATRIX_SIZE < 5)
            {
                loaded = false;
                ErrorMsg("Неверная размерность матрицы");
                return;
            }

            if(timerOn)
            {
                button_timer_Click();
            }

            one_cell = main_pictureBox.Width / (MATRIX_SIZE + 2);

            g.Clear(Color.White);

            pheromone = new int[MATRIX_SIZE + 2, MATRIX_SIZE + 2];
            eat = new bool[MATRIX_SIZE, MATRIX_SIZE];

            for (int i = 0; i < MATRIX_SIZE + 2; i++)
                for (int j = 0; j < MATRIX_SIZE + 2; j++)
                {
                    if (i == 0 || i == MATRIX_SIZE + 2 - 1 || j == 0 || j == MATRIX_SIZE + 2 - 1)
                        pheromone[i, j] = -1;
                    else
                        pheromone[i, j] = 0;
                }

            for (int i = 0; i < MATRIX_SIZE + 2; i++)
            {
                for (int j = 0; j < MATRIX_SIZE + 2; j++)
                {
                    g.DrawRectangle(frame_line, one_cell * i, one_cell * j, one_cell, one_cell);

                    if (i == 0 || i == MATRIX_SIZE + 2 - 1 || j == 0 || j == MATRIX_SIZE + 2 - 1)
                        g.DrawString("-1", new Font("Arial", one_cell / 3), Brushes.Red, one_cell * j + one_cell / 5, one_cell * i + one_cell / 5);

                    setPheromone(i, j, pheromone[i, j]);
                }
            }

            ant[0] = 1; ant[1] = 1;

            eatCount = 0;
            label_eatCount.Text = "0";

            goHome = false;

            startX = startY = 1;
            updateAnt(startX, startY);

            loaded = true;
        }

        public Form1()
        {
            InitializeComponent();

            timer.Elapsed += Timer_Elapsed;

            g = Graphics.FromHwnd(main_pictureBox.Handle);
            frame_line = new Pen(Color.Black, 1);

            /*
            pheromone = new int[,] {
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 },
                { -1, 1, 2, 2, 1, 1, 0, 0, 1, 2, 2, -1 },
                { -1, 0, 0, 0, 2, 0, 1, 0, 0, 0, 2, -1 },
                { -1, 0, 0, 0, 0, 3, 0, 1, 0, 0, 2, -1 },
                { -1, 0, 0, 0, 3, 0, 0, 0, 1, 0, 2, -1 },
                { -1, 0, 0, 0, 3, 0, 0, 1, 0, 0, 2, -1 },
                { -1, 0, 0, 0, 0, 3, 0, 0, 1, 0, 2, -1 },
                { -1, 0, 0, 0, 2, 4, 1, 0, 1, 0, 2, -1 },
                { -1, 0, 0, 1, 0, 1, 5, 1, 0, 1, 2, -1 },
                { -1, 0, 0, 1, 0, 1, 2, 6, 6, 6, 3, -1 },
                { -1, 0, 0, 0, 2, 2, 2, 3, 3, 3, 10, -1 },
                { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 }
            };
            // */
        }

        private void button_nextStep_Click(object sender = null, EventArgs e = null)
        {
            if (!loaded)
                return;

            if (goHome && ant[0] == startX && ant[1] == startY) //На поиски еды
            {
                goHome = !goHome;
                updateAnt(ant[0], ant[1]);
                
                label_eatCount.Invoke(new Action(() => { label_eatCount.Text = (++eatCount).ToString(); }));
            }

            if(!goHome && eat[ant[0] - 1, ant[1] - 1]) //Берем еду
            {
                updateEat(ant[0], ant[1], false);
                goHome = !goHome;
                updateAnt(ant[0], ant[1]);
            }

            if (!goHome)
            {
                pheromone[ant[0], ant[1]] += 2;    
            }
            else
                if(pheromone[ant[0], ant[1]] > 0)
                    pheromone[ant[0], ant[1]] -= 1;

            setPheromone(ant[0], ant[1], pheromone[ant[0], ant[1]]);

            int next = generateNextStep();
            
            updateAnt(ant_near[next, 0], ant_near[next, 1]);
        }

        private void setPheromone(int i, int j, int val = -1)
        {
            if (i <= 0 || j <= 0 || i >= MATRIX_SIZE + 2 - 1 || j >= MATRIX_SIZE + 2 - 1)
                return;

            g.DrawString(val.ToString(), new Font("Arial", one_cell / 3), Brushes.Green, one_cell * j + one_cell / 5, one_cell * i + one_cell / 5);
        }//2 1

        private void updateAnt(int i, int j)
        {
            if (i <= 0 || j <= 0 || i >= MATRIX_SIZE + 2 - 1 || j >= MATRIX_SIZE + 2 - 1)
                return;

            g.FillRectangle(Brushes.White, one_cell * ant[1] + 1, one_cell * ant[0] + 1, one_cell - 1, one_cell - 1);
            setPheromone(ant[0], ant[1], pheromone[ant[0], ant[1]]);
            g.FillRectangle(goHome ? Brushes.RoyalBlue : Brushes.Gold, one_cell * j + 1, one_cell * i + 1, one_cell - 1, one_cell - 1);
            setPheromone(i, j, pheromone[i, j]);

            updateEat(ant[0], ant[1], eat[ant[0] - 1, ant[1] - 1]);

            ant[0] = i; ant[1] = j;

            /*if (goHome || !goHome)
            {*/
                ant_near[0, 0] = ant[0] + 1; ant_near[0, 1] = ant[1] + 1;
                ant_near[1, 0] = ant[0] + 1; ant_near[1, 1] = ant[1];
                ant_near[2, 0] = ant[0];     ant_near[2, 1] = ant[1] + 1;
                ant_near[3, 0] = ant[0] + 1; ant_near[3, 1] = ant[1] - 1;
                ant_near[4, 0] = ant[0] - 1; ant_near[4, 1] = ant[1] + 1;
                ant_near[5, 0] = ant[0];     ant_near[5, 1] = ant[1] - 1;
                ant_near[6, 0] = ant[0] - 1; ant_near[6, 1] = ant[1];
                ant_near[7, 0] = ant[0] - 1; ant_near[7, 1] = ant[1] - 1;
            /*}
            else
            {
                ant_near[0, 0] = ant[0] - 1; ant_near[0, 1] = ant[1] - 1;
                ant_near[1, 0] = ant[0] - 1; ant_near[1, 1] = ant[1];
                ant_near[2, 0] = ant[0];     ant_near[2, 1] = ant[1] - 1;
                ant_near[3, 0] = ant[0] - 1; ant_near[3, 1] = ant[1] + 1;
                ant_near[4, 0] = ant[0] + 1; ant_near[4, 1] = ant[1] - 1;
                ant_near[5, 0] = ant[0];     ant_near[5, 1] = ant[1] + 1;
                ant_near[6, 0] = ant[0] + 1; ant_near[6, 1] = ant[1];
                ant_near[7, 0] = ant[0] + 1; ant_near[7, 1] = ant[1] + 1;
            }*/
        }

        private void updateEat(int i, int j, bool val)
        {
            if (i <= 0 || j <= 0 || i > MATRIX_SIZE || j > MATRIX_SIZE || !loaded)
                return;

            eat[i - 1, j - 1] = val;

            //if (ant[0] == i && ant[1] == j)
                //return;

            if(val)
                g.FillRectangle(Brushes.Crimson, one_cell * j + 1, one_cell * i + 1, one_cell - 1, one_cell - 1);
            else
                g.FillRectangle(Brushes.White, one_cell * j + 1, one_cell * i + 1, one_cell - 1, one_cell - 1);
            setPheromone(i, j, pheromone[i, j]);
        }

        private int generateNextStep()
        {
            var same_cells = new List<int>();
            //Выбираем первую не = -1
            int fer_value = 0;
            for (int i = 0; i < 8; i++)
                if (pheromone[ant_near[i, 0], ant_near[i, 1]] != -1)
                {
                    fer_value = i;
                    break;
                }

            if (goHome)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (pheromone[ant_near[i, 0], ant_near[i, 1]] > pheromone[ant_near[fer_value, 0], ant_near[fer_value, 1]])
                        fer_value = i;
                }
            }
            else
            {
                //Ищем минимальную
                for (int i = 0; i < 8; i++)
                {
                    if(pheromone[ant_near[i, 0], ant_near[i, 1]] > -1)
                        if (eat[ant_near[i, 0] - 1, ant_near[i, 1] - 1])
                            return i;
                    
                    if (pheromone[ant_near[i, 0], ant_near[i, 1]] < pheromone[ant_near[fer_value, 0], ant_near[fer_value, 1]] && pheromone[ant_near[i, 0], ant_near[i, 1]] != -1)
                        fer_value = i;
                }
            }

            //Пробегаемся по минимальным, добавляем в список
            for (int i = 0; i < 8; i++)
            {
                if (pheromone[ant_near[i, 0], ant_near[i, 1]] == pheromone[ant_near[fer_value, 0], ant_near[fer_value, 1]])
                    same_cells.Add(i);
            }

            if (same_cells.Count <= 1)
                return fer_value;

            //Выбираем одну рандомом
            else
                return same_cells[new Random().Next(same_cells.Count)];
        }

        private void button_randEat_Click(object sender, EventArgs e)
        {
            if (!loaded || timerOn)
                return;

            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 1; i <= MATRIX_SIZE; i++)
            {
                for (int j = 1; j <= MATRIX_SIZE; j++)
                {
                    if (random.Next(RANDOM_GENERATE) == 0)
                        updateEat(j, i, true);
                    else
                        updateEat(j, i, false);
                }
            }

            updateAnt(ant[0], ant[1]);
        }

        private void button_timer_Click(object sender = null, EventArgs e = null)
        {
            if (!loaded)
                return;

            if (!timerOn)
            {
                timer.Start();
                button_timer.Text = "timer off";
            }
            else
            {
                timer.Stop();
                button_timer.Text = "timer on";
            }
            timerOn = !timerOn;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            button_nextStep_Click();
        }

        private void button_setHome_Click(object sender, EventArgs e)
        {
            setHome = !setHome;
        }

        private void trackBar_timerTick_Scroll(object sender, EventArgs e)
        {
            System.Windows.Forms.TrackBar myTB;
            myTB = (System.Windows.Forms.TrackBar)sender;
            timer.Interval = myTB.Value;
        }

        private void main_pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (timerOn)
                return;

            int i, j;
            i = e.X / one_cell > MATRIX_SIZE + 2 - 1 ? MATRIX_SIZE + 2 - 1 : e.X / one_cell;
            j = e.Y / one_cell > MATRIX_SIZE + 2 - 1 ? MATRIX_SIZE + 2 - 1 : e.Y / one_cell;

            if (setHome)
            {
                startX = j;
                startY = i;
                setHome = false;
                updateAnt(startX, startY);
                return;
            }

            if (i == 0 || j == 0)
                return;

            updateEat(j, i, !eat[j - 1, i - 1]);
        }

        private int ErrorMsg(string str)
        {
            MessageBox.Show(str, "Error");
            return 0;
        }

    }
}
