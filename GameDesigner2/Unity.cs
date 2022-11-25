using GameDesigner2.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameDesigner2
{
    #region 正在使用的资源
    enum DesignerPointer
    {
        Wall, Wall2, Destroy, Player, Enemy, Born, Cookie, FullSpeed
    }
    #endregion
    //存在无法解决的问题，form窗体尺寸不正确，在100%设置916*939 已解决
    internal class Unity
    {
        #region 游戏属性
        public static bool GameFlag;//游戏运行开关
        public static bool GameDesignFlag;//游戏设计开关
        public static DesignerPointer DP = DesignerPointer.Wall;//正在使用的材料
        public static int[,] GameDate = new int[30, 30];//游戏数据
        //private static int FPSCount = 0;//FPS 没有线程休眠，极限大概在58.3帧
        private static Player player;
        private static List<Stationary> WallList = new List<Stationary>();//可摧毁墙
        private static List<Stationary> Wall2List = new List<Stationary>();//不可摧毁墙
        private static List<Enemy> EnemyList = new List<Enemy>();//敌人
        private static List<Bullet> BulletList = new List<Bullet>();//子弹
        private static List<Explosion> ExplosionList = new List<Explosion>();//正在爆炸
        //private static Object _bullectLock = new object();//子弹线程锁,无效，同线程内操作
        //private static Point[] points = new Point[3];//敌人刷新点
        private static List<Stationary> BornList = new List<Stationary>();//敌人刷新点
        public static Stationary Cookie;//小饼干
        private static List<Stationary> FullSpeedList = new List<Stationary>();//加速！
        public static int enemyBornSpeed = 60;//雪怪刷新频率
        private static int enemyBornCount = 60;
        public static Graphics UnityGraphic;//引擎画布
        private static Pen pen = new Pen(Color.Gray);//辅助线画笔
        private static Rectangle MouseRect = new Rectangle(850, 850, 1, 1);//鼠标矩形
        private static Object _wallLock = new object();//wall线程锁
        private static Object _wall2Lock = new object();//wall2线程锁
        private static Object _enemyLock = new object();//enemy线程锁
        private static Object _bornLock = new object();//born锁
        public static Object _fullSpeedLock = new object();//加速锁
        #endregion
        public static void Start()
        {
            GameFlag = true;
            GameDesignFlag = false;
            SoundManager.InitSound();
            SoundManager.PlayBGM();
            CreateMap();
            CreatePlayer(15, 15, Settings.playerSpeed);
            InitBornList();
        }
        public static void Update()
        {
            //先清空一下画布
            Unity.UnityGraphic.Clear(Color.White);
            if (GameFlag == false)
            {
                DrawGuides();
            }
            //画墙
            lock (_wallLock)
            {
                for (int i = 0; i < WallList.Count; i++)
                {
                    WallList[i].Update();
                }
            }
            lock (_wall2Lock)
            {
                for (int i = 0; i < Wall2List.Count; i++)
                {
                    Wall2List[i].Update();
                }
            }
            lock (_bornLock)
            {
                for (int i = 0; i < BornList.Count; i++)
                {
                    BornList[i].Update();
                }
            }
            lock (_fullSpeedLock)
            {
                for (int i = 0; i < FullSpeedList.Count; i++)
                {
                    FullSpeedList[i].Update();
                }
            }
            //生成敌人
            EnemyBorn();
            lock (_enemyLock)
            {
                for (int i = 0; i < EnemyList.Count; i++)
                {
                    EnemyList[i].Update();
                }
            }
            //画饼干
            if (Cookie != null)
            {
                Cookie.Update();
            }
            //画子弹
            CheckAndDestoryBullet();
            for (int i = 0; i < BulletList.Count; i++)
            {
                BulletList[i].Update();
            }
            //画玩家
            if (player != null)
            {
                player.Update();
            }
            //画爆炸
            CheckAndDestoryExplosion();
            for (int i = 0; i < ExplosionList.Count; i++)
            {
                ExplosionList[i].Update();
            }
        }
        #region 创建地图+玩家
        public static void CreateMap()
        {
            CreateWall(0, 0, Properties.Resources.wall, WallList);
            CreateWall(1, 1, Properties.Resources.wall, WallList);
            CreateWall(1, 2, Properties.Resources.wall, WallList);
            CreateWall(1, 3, Properties.Resources.wall, WallList);
            CreateWall(1, 4, Properties.Resources.wall, WallList);
            CreateWall(1, 5, Properties.Resources.wall, WallList);
            CreateWall(1, 6, Properties.Resources.wall, WallList);
            CreateWall(1, 7, Properties.Resources.wall, WallList);
            CreateWall2(2, 2, Properties.Resources.wall2, Wall2List);
            CreateWall2(3, 3, Properties.Resources.wall2, Wall2List);
            CreateWall(4, 4, Properties.Resources.wall, WallList);
        }
        public static void CreateWall(int x, int y, Image img, List<Stationary> WallList)
        {
            GameDate[x, y] = 1;
            x *= 30;
            y *= 30;
            Stationary wall = new Stationary(x, y, img);
            WallList.Add(wall);
        }
        public static void CreateWall2(int x, int y, Image img, List<Stationary> Wall2List)
        {
            GameDate[x, y] = 2;
            x *= 30;
            y *= 30;
            Stationary wall2 = new Stationary(x, y, img);
            //MessageBox.Show(Convert.ToString(wall2.Width));

            Wall2List.Add(wall2);
        }
        public static void CreateBorn(int x, int y, Image img, List<Stationary> BornList)
        {
            GameDate[x, y] = 5;
            x *= 30;
            y *= 30;
            Stationary born = new Stationary(x, y, img);
            BornList.Add(born);
        }
        public static void CreatePlayer(int x, int y, int speed)
        {
            GameDate[x, y] = 3;
            x *= 30;
            y *= 30;
            player = new Player(x, y, speed);
        }
        public static void CreateCookie(int x, int y)
        {
            GameDate[x, y] = 6;
            x *= 30;
            y *= 30;
            Cookie = new Stationary(x, y, Resources.cookie);
        }
        public static void CreateFullSpeed(int x, int y, Image img, List<Stationary> FullSpeedList)
        {
            GameDate[x, y] = 7;
            x *= 30;
            y *= 30;
            Stationary fullSpeed = new Stationary(x, y, img);
            FullSpeedList.Add(fullSpeed);
        }
        #endregion
        #region 键盘事件
        public static void KeyDown(KeyEventArgs e)
        {
            if (player != null)
            {
                player.KeyDown(e);
            }
        }
        public static void KeyUp(KeyEventArgs e)
        {
            if (player != null)
            {
                player.KeyUp(e);
            }
        }
        #endregion 
        #region 碰撞检测
        //碰撞可破坏墙
        public static Stationary IsCollidedWall(Rectangle rt)
        {
            lock (_wallLock)
            {
                foreach (Stationary wall in WallList)
                {
                    if (wall.GetRectangle().IntersectsWith(rt))
                    {
                        return wall;
                    }
                }
            }
            return null;
        }
        //碰撞不可破坏墙
        public static Stationary IsCollidedWall2(Rectangle rt)
        {
            lock (_wall2Lock)
            {
                foreach (Stationary wall2 in Wall2List)
                {
                    if (wall2.GetRectangle().IntersectsWith(rt))
                    {
                        return wall2;
                    }
                }
            }
            return null;
        }
        //碰撞敌人复活点
        public static Stationary IsCollidedBorn(Rectangle rt)
        {
            lock (_bornLock)
            {
                foreach (Stationary born in BornList)
                {
                    if (born.GetRectangle().IntersectsWith(rt))
                    {
                        return born;
                    }
                }
            }
            return null;
        }
        //碰撞敌人
        public static Enemy IsCollidedEnemy(Rectangle rt)
        {
            foreach (Enemy enemy in EnemyList)
            {
                if (enemy.GetRectangle().IntersectsWith(rt))
                {
                    return enemy;
                }
            }
            return null;
        }
        //碰到饼干
        public static Stationary IsCollidedCookie(Rectangle rt)
        {
            if (Cookie.GetRectangle().IntersectsWith(rt))
            {
                return Cookie;
            }
            return null;
        }
        //碰撞加速
        public static Stationary IsCollidedFullSpeed(Rectangle rt)
        {
            lock (_fullSpeedLock)
            {
                foreach (Stationary fullSpeed in FullSpeedList)
                {
                    if (fullSpeed.GetRectangle().IntersectsWith(rt))
                    {
                        return fullSpeed;
                    }
                }
            }
            return null;
        }

        //摧毁掉墙
        public static void DestroyWall(Stationary wall)
        {
            lock (_wallLock)
            {
                WallList.Remove(wall);
            }
            GameDate[wall.X / 30, wall.Y / 30] = 0;
        }
        public static void DestroyWall2(Stationary wall2)
        {
            lock (_wall2Lock)
            {
                Wall2List.Remove(wall2);
            }
            GameDate[wall2.X / 30, wall2.Y / 30] = 0;
        }
        public static void DestroyBorn(Stationary born)
        {
            lock (_bornLock)
            {
                BornList.Remove(born);
            }
            GameDate[born.X / 30, born.Y / 30] = 0;
        }
        //销毁敌人
        public static void DestroyEnemy(Enemy enemy)
        {
            lock (_enemyLock)
            {
                EnemyList.Remove(enemy);
            }
            GameDate[enemy.X / 30, enemy.Y / 30] = 0;
        }
        public static void DestroyFullSpeed(Stationary fullSpeed)
        {
            lock (_fullSpeedLock)
            {
                FullSpeedList.Remove(fullSpeed);
            }
            GameDate[fullSpeed.X / 30, fullSpeed.Y / 30] = 0;
        }

        #endregion
        #region 敌人
        public static void InitBornList()
        {
            CreateBorn(24, 5, Properties.Resources.born, BornList);
            CreateBorn(5, 9, Properties.Resources.born, BornList);
            CreateBorn(12, 23, Properties.Resources.born, BornList);
        }
        public static void EnemyBorn()
        {
            enemyBornCount++;
            if (enemyBornCount < enemyBornSpeed) return;
            if (BornList.Count < 1) return;
            Random rd = new Random();
            int index = rd.Next(0, BornList.Count);
            if (GameFlag == true)
            {
                CreateEnemy(BornList[index].X / 30, BornList[index].Y / 30, Settings.enemySpeed);
            }
            enemyBornCount = 0;
        }
        public static void CreateEnemy(int x, int y, int speed)
        {
            GameDate[x, y] = 4;
            x *= 30;
            y *= 30;
            Enemy enemy = new Enemy(x, y, speed);
            EnemyList.Add(enemy);
        }
        #endregion
        #region 子弹
        //生成子弹
        public static void CreateBullet(int x, int y, Direction dir, Tag tag)
        {
            Bullet bullet = new Bullet(x, y, 10, dir, tag);

            BulletList.Add(bullet);
        }
        //检查，并且销毁
        //避免在同一线程内，在遍历的同时删除某个元素导致的bug
        private static void CheckAndDestoryBullet()
        {
            List<Bullet> BulletToDestory = new List<Bullet>();
            foreach (Bullet bullet in BulletList)
            {
                if (bullet.IsDestroy == true)
                {
                    BulletToDestory.Add(bullet);
                }
            }
            foreach (Bullet bullet in BulletToDestory)
            {
                BulletList.Remove(bullet);
            }
        }
        #endregion
        #region 爆炸
        public static void CreateExplosion(int x, int y)
        {
            Explosion explosion = new Explosion(x, y);
            ExplosionList.Add(explosion);
        }
        //检查，并且销毁
        //避免在同一线程内，在遍历的同时删除某个元素导致的bug
        private static void CheckAndDestoryExplosion()
        {
            List<Explosion> ExplosionToDestory = new List<Explosion>();
            foreach (Explosion explosion in ExplosionList)
            {
                if (explosion.IsDestroy == true)
                {
                    ExplosionToDestory.Add(explosion);
                }
            }
            foreach (Explosion explosion in ExplosionToDestory)
            {
                ExplosionList.Remove(explosion);
            }
        }
        #endregion
        #region 帧数
        //public static void testFPS()
        //{
        //    FPSCount++;
        //    if (FPSCount == 1750)
        //    {
        //        MessageBox.Show("1750");
        //    }
        //}
        #endregion
        #region 游戏设计器
        //设计器辅助线
        private static void DrawGuides()
        {
            Point start = new Point(0, 0);
            Point end = new Point(900, 0);
            for (int i = 30; i < 900; i += 30)
            {
                start.Y += 30;
                end.Y += 30;
                UnityGraphic.DrawLine(pen, start, end);
            }
            start.Y = 0;
            start.X = 0;
            end.X = 0;
            end.Y = 900;
            for (int i = 30; i < 900; i += 30)
            {
                start.X += 30;
                end.X += 30;
                UnityGraphic.DrawLine(pen, start, end);
            }
        }
        //鼠标添加
        public static void MouseDown(MouseEventArgs e)
        {
            if (!GameFlag) GameDesignFlag = true;
        }
        public static void MouseUp(MouseEventArgs e)
        {
            GameDesignFlag = false;
        }
        public static void MouseMove(MouseEventArgs e)
        {
            //出界
            if (e.X > 899 || e.Y > 899) return;
            int x = e.X / 30;
            int y = e.Y / 30;
            if (GameDesignFlag)
            {
                if (GameDate[x, y] == 0)
                {
                    //添加
                    switch (DP)
                    {
                        case DesignerPointer.Wall:
                            lock (_wallLock)
                            {
                                CreateWall(x, y, Resources.wall, WallList);
                            }
                            break;
                        case DesignerPointer.Wall2:
                            lock (_wall2Lock)
                            {
                                CreateWall2(x, y, Resources.wall2, Wall2List);
                            }
                            break;
                        case DesignerPointer.Player:
                            if (player == null)
                            {
                                CreatePlayer(x, y, Settings.playerSpeed);
                            }
                            break;
                        case DesignerPointer.Enemy:
                            lock (_enemyLock)
                            {
                                CreateEnemy(x, y, Settings.enemySpeed);
                            }
                            break;
                        case DesignerPointer.Born:
                            lock (_bornLock)
                            {
                                CreateBorn(x, y, Resources.born, BornList);
                            }
                            break;
                        case DesignerPointer.Cookie:
                            if (Cookie == null)
                            {
                                CreateCookie(x, y);
                            }
                            break;
                        case DesignerPointer.FullSpeed:
                            lock (_fullSpeedLock)
                            {
                                CreateFullSpeed(x, y, Resources.speed, FullSpeedList);
                            }
                            break;
                    }
                }
                else if (DP == DesignerPointer.Destroy)
                {
                    //销毁
                    MouseRect.X = e.X;
                    MouseRect.Y = e.Y;
                    Stationary stationary;
                    Enemy enemy;
                    if (GameDate[x, y] == 1)
                    {
                        if ((stationary = IsCollidedWall(MouseRect)) != null)
                        {
                            DestroyWall(stationary);
                        }
                    }
                    else if (GameDate[x, y] == 2)
                    {
                        if ((stationary = IsCollidedWall2(MouseRect)) != null)
                        {
                            DestroyWall2(stationary);
                        }
                    }
                    else if (GameDate[x, y] == 3)
                    {
                        player = null;
                        GameDate[x, y] = 0;
                    }
                    else if (GameDate[x, y] == 4)
                    {
                        if ((enemy = IsCollidedEnemy(MouseRect)) != null)
                        {
                            DestroyEnemy(enemy);
                        }
                    }
                    else if (GameDate[x, y] == 5)
                    {
                        if ((stationary = IsCollidedBorn(MouseRect)) != null)
                        {
                            DestroyBorn(stationary);
                        }
                    }
                    else if (GameDate[x, y] == 6)
                    {
                        Cookie = null;
                        GameDate[x, y] = 0;
                    }
                    else if (GameDate[x, y] == 7)
                    {
                        if ((stationary = IsCollidedFullSpeed(MouseRect)) != null)
                        {
                            DestroyFullSpeed(stationary);
                        }
                    }
                }
            }
        }
        //清理全部
        public static void ClearAll()
        {
            GameFlag = false;
            lock (_wallLock)
            {
                WallList.Clear();
            }
            lock (_wall2Lock)
            {
                Wall2List.Clear();
            }
            player = null;
            lock (_enemyLock)
            {
                EnemyList.Clear();
            }
            lock (_bornLock)
            {
                BornList.Clear();
            }
            Cookie = null;
            lock (_fullSpeedLock)
            {
                FullSpeedList.Clear();
            }
        }
        #endregion
        #region 游戏结束
        public static void GameOver()
        {
            GameFlag = false;
            MessageBox.Show("雪怪吃掉了你的饼干！！！");
        }
        #endregion
    }
}
