using AMath;
using System.Linq;

namespace Visualizer
{
    public class TourDeEifel : Mesh
    {
        public int flagCount;
        public double length;
        public double width;
        public double height;
        public int arcCount;
        public double thirdWidth;
        public double thirdHeight;
        public double flagHeigth;
        public double flagWidth;
        public double supportWidth;
        public double supportHeight;
        public double antenaHeigth;
        public double controle;

        public TourDeEifel(int flagCount, double length, double width, double height, int arcCount,
            double thirdWidth, double thirdHeight, double flagHeigth, double flagWidth, 
            double supportWidth, double supportHeight, double antenaHeigth, double controle)
        {
            this.flagCount = flagCount;
            this.length = length;
            this.width = width;
            this.height = height;
            this.arcCount = arcCount;
            this.thirdWidth = thirdWidth;
            this.thirdHeight = thirdHeight;
            this.flagHeigth = flagHeigth;
            this.flagWidth = flagWidth;
            this.supportWidth = supportWidth;
            this.supportHeight = supportHeight;
            this.antenaHeigth = antenaHeigth;
            this.controle = controle;
            int vertCount = 0;

            // Башенные опоры

            Mesh support1 = MeshCreater.Box(new Vertex(-9.5, 0, 9.5), supportWidth, supportWidth, supportHeight);
            vertCount = Verteces.Count;
            Verteces.AddRange(support1.Verteces);
            Faces.AddRange(support1.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh support2 = MeshCreater.Box(new Vertex(-9.5, 0, -9.5), supportWidth, supportWidth, supportHeight);
            vertCount = Verteces.Count;
            Verteces.AddRange(support2.Verteces);
            Faces.AddRange(support2.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh support3 = MeshCreater.Box(new Vertex(9.5, 0, 9.5), supportWidth, supportWidth, supportHeight);
            vertCount = Verteces.Count;
            Verteces.AddRange(support3.Verteces);
            Faces.AddRange(support3.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh support4 = MeshCreater.Box(new Vertex(9.5, 0, -9.5), supportWidth, supportWidth, supportHeight);
            vertCount = Verteces.Count;
            Verteces.AddRange(support4.Verteces);
            Faces.AddRange(support4.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            // 1-й этаж

            Mesh firstFloor = MeshCreater.Box(new Vertex(0, 12, 0), 16, 16, 2);
            vertCount = Verteces.Count;
            Verteces.AddRange(firstFloor.Verteces);
            Faces.AddRange(firstFloor.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            // Внешние стойки 1-го этажа

            Mesh rack11 = MeshCreater.LinearCurve1(new Vertex(-12, 1, 12), new Vertex(-7.5, 12, 7.5), 4);
            vertCount = Verteces.Count;
            Verteces.AddRange(rack11.Verteces);
            Faces.AddRange(rack11.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh rack21 = MeshCreater.LinearCurve1(new Vertex(8, 1, 12), new Vertex(3.5, 12, 7.5), 4);
            vertCount = Verteces.Count;
            Verteces.AddRange(rack21.Verteces);
            Faces.AddRange(rack21.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh rack31 = MeshCreater.LinearCurve1(new Vertex(8, 1, -12), new Vertex(3.5, 12, -7.5), 4);
            vertCount = Verteces.Count;
            Verteces.AddRange(rack31.Verteces);
            Faces.AddRange(rack31.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh rack41 = MeshCreater.LinearCurve1(new Vertex(-12, 1, -12), new Vertex(-7.5, 12, -7.5), 4);
            vertCount = Verteces.Count;
            Verteces.AddRange(rack41.Verteces);
            Faces.AddRange(rack41.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            // Внутренние стойки 1-го этажа

            Mesh rack12 = MeshCreater.LinearCurve2(new Vertex(-12, 1, 12), new Vertex(-7.5, 12, 7.5), 4);
            vertCount = Verteces.Count;
            Verteces.AddRange(rack12.Verteces);
            Faces.AddRange(rack12.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh rack22 = MeshCreater.LinearCurve2(new Vertex(12, 1, 12), new Vertex(7.5, 12, 7.5), 4);
            vertCount = Verteces.Count;
            Verteces.AddRange(rack22.Verteces);
            Faces.AddRange(rack22.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh rack32 = MeshCreater.LinearCurve2(new Vertex(12, 1, -8), new Vertex(7.5, 12, -3.5), 4);
            vertCount = Verteces.Count;
            Verteces.AddRange(rack32.Verteces);
            Faces.AddRange(rack32.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh rack42 = MeshCreater.LinearCurve2(new Vertex(-12, 1, -8), new Vertex(-7.5, 12, -3.5), 4);
            vertCount = Verteces.Count;
            Verteces.AddRange(rack42.Verteces);
            Faces.AddRange(rack42.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            // Арки 1-го этажа

            Mesh arch1 = MeshCreater.QuadraticCurve1(new Vertex(-8, 1, -12), new Vertex(0, 18, -5), new Vertex(7, 1, -12), 0.2);
            vertCount = Verteces.Count;
            Verteces.AddRange(arch1.Verteces);
            Faces.AddRange(arch1.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh arch2 = MeshCreater.QuadraticCurve1(new Vertex(7, 1, 12), new Vertex(0, 18, 5), new Vertex(-8, 1, 12), 0.2);
            vertCount = Verteces.Count;
            Verteces.AddRange(arch2.Verteces);
            Faces.AddRange(arch2.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh arch3 = MeshCreater.QuadraticCurve2(new Vertex(-12, 1, 8), new Vertex(-5, 18, 0), new Vertex(-12, 1, -7), 0.2);
            vertCount = Verteces.Count;
            Verteces.AddRange(arch3.Verteces);
            Faces.AddRange(arch3.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh arch4 = MeshCreater.QuadraticCurve2(new Vertex(12, 1, -7), new Vertex(5, 18, 0), new Vertex(12, 1, 8), 0.2);
            vertCount = Verteces.Count;
            Verteces.AddRange(arch4.Verteces);
            Faces.AddRange(arch4.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            // 2-й этаж

            Mesh secondFloor = MeshCreater.Box(new Vertex(0, 23, 0), 12, 12, 2);
            vertCount = Verteces.Count;
            Verteces.AddRange(secondFloor.Verteces);
            Faces.AddRange(secondFloor.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            // 3-й этаж

            Mesh thirdFloor = MeshCreater.Box(new Vertex(0, 56, 0), thirdWidth, thirdWidth, thirdHeight);
            vertCount = Verteces.Count;
            Verteces.AddRange(thirdFloor.Verteces);
            Faces.AddRange(thirdFloor.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            // Внешние дугаобразные стойки

            Mesh rack51 = MeshCreater.QuadraticCurve3(new Vertex(-7.5, 12, 7.5), new Vertex(0, 34, 1), new Vertex(-0.5, 56, 0.5), new Vertex(-3.5, 12, 7.5));
            vertCount = Verteces.Count;
            Verteces.AddRange(rack51.Verteces);
            Faces.AddRange(rack51.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            // Внутренние дугаобразные стойки

            Mesh rack52 = MeshCreater.QuadraticCurve3(new Vertex(-7.5, 12, 7.5), new Vertex(0, 34, 1), new Vertex(-0.5, 56, 0.5), new Vertex(-7.5, 12, 3.5));
            vertCount = Verteces.Count;
            Verteces.AddRange(rack52.Verteces);
            Faces.AddRange(rack52.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh rack61 = MeshCreater.QuadraticCurve3(new Vertex(7.5, 12, -7.5), new Vertex(0, 34, 1), new Vertex(0.5, 56, -0.5), new Vertex(7.5, 12, -3.5));
            vertCount = Verteces.Count;
            Verteces.AddRange(rack61.Verteces);
            Faces.AddRange(rack61.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh rack62 = MeshCreater.QuadraticCurve3(new Vertex(7.5, 12, -7.5), new Vertex(0, 34, 1), new Vertex(0.5, 56, -0.5), new Vertex(3.5, 12, -7.5));
            vertCount = Verteces.Count;
            Verteces.AddRange(rack62.Verteces);
            Faces.AddRange(rack62.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh rack71 = MeshCreater.QuadraticCurve3(new Vertex(-7.5, 12, -7.5), new Vertex(0, 34, 1), new Vertex(-0.5, 56, -0.5), new Vertex(-3.5, 12, -7.5));
            vertCount = Verteces.Count;
            Verteces.AddRange(rack71.Verteces);
            Faces.AddRange(rack71.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh rack72 = MeshCreater.QuadraticCurve3(new Vertex(-7.5, 12, -7.5), new Vertex(0, 34, 1), new Vertex(-0.5, 56, -0.5), new Vertex(-7.5, 12, -3.5));
            vertCount = Verteces.Count;
            Verteces.AddRange(rack72.Verteces);
            Faces.AddRange(rack72.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh rack81 = MeshCreater.QuadraticCurve3(new Vertex(7.5, 12, 7.5), new Vertex(0, 34, 1), new Vertex(0.5, 56, 0.5), new Vertex(3.5, 12, 7.5));
            vertCount = Verteces.Count;
            Verteces.AddRange(rack81.Verteces);
            Faces.AddRange(rack81.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            Mesh rack82 = MeshCreater.QuadraticCurve3(new Vertex(7.5, 12, 7.5), new Vertex(0, 34, 1), new Vertex(0.5, 56, 0.5), new Vertex(7.5, 12, 3.5));
            vertCount = Verteces.Count;
            Verteces.AddRange(rack82.Verteces);
            Faces.AddRange(rack82.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            // Шпиль

            Mesh spire = MeshCreater.Box(new Vertex(0, 57, 0), 1, 1, 2);
            vertCount = Verteces.Count;
            Verteces.AddRange(spire.Verteces);
            Faces.AddRange(spire.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            // Антена

            Mesh antenna = MeshCreater.Box(new Vertex(0, 59, 0), 0.1, 0.1, antenaHeigth);
            vertCount = Verteces.Count;
            Verteces.AddRange(antenna.Verteces);
            Faces.AddRange(antenna.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

            // Сигнальные флажки
            Mesh flag1 = MeshCreater.Box(new Vertex(1.5, 57, 1.5), flagWidth, flagWidth, flagHeigth);
            Mesh flag2 = MeshCreater.Box(new Vertex(-1.5, 57, -1.5), flagWidth, flagWidth, flagHeigth);
            Mesh flag3 = MeshCreater.Box(new Vertex(-1.5, 57, 1.5), flagWidth, flagWidth, flagHeigth);
            Mesh flag4 = MeshCreater.Box(new Vertex(1.5, 57, -1.5), flagWidth, flagWidth, flagHeigth);

            switch (flagCount)
            {
                case 1:
                    vertCount = Verteces.Count;
                    Verteces.AddRange(flag1.Verteces);
                    Faces.AddRange(flag1.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));
                    break;

                case 2:
                    vertCount = Verteces.Count;
                    Verteces.AddRange(flag1.Verteces);
                    Faces.AddRange(flag1.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

                    vertCount = Verteces.Count;
                    Verteces.AddRange(flag2.Verteces);
                    Faces.AddRange(flag2.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));
                    break;

                case 3:
                    vertCount = Verteces.Count;
                    Verteces.AddRange(flag1.Verteces);
                    Faces.AddRange(flag1.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

                    vertCount = Verteces.Count;
                    Verteces.AddRange(flag2.Verteces);
                    Faces.AddRange(flag2.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

                    vertCount = Verteces.Count;
                    Verteces.AddRange(flag3.Verteces);
                    Faces.AddRange(flag3.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));
                    break;

                case 4:
                    vertCount = Verteces.Count;
                    Verteces.AddRange(flag1.Verteces);
                    Faces.AddRange(flag1.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

                    vertCount = Verteces.Count;
                    Verteces.AddRange(flag2.Verteces);
                    Faces.AddRange(flag2.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

                    vertCount = Verteces.Count;
                    Verteces.AddRange(flag3.Verteces);
                    Faces.AddRange(flag3.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

                    vertCount = Verteces.Count;
                    Verteces.AddRange(flag4.Verteces);
                    Faces.AddRange(flag4.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));
                    break;
            }

            // Дуги на последнем этаже
            Mesh arch5 = MeshCreater.QuadraticCurve1(new Vertex(1, 57, 1), new Vertex(1.5, 59, 1.5), new Vertex(0, 61, 0), 0.05);
            Mesh arch6 = MeshCreater.QuadraticCurve1(new Vertex(-1, 57, -1), new Vertex(-1.5, 59, -1.5), new Vertex(0, 61, 0), 0.05);
            Mesh arch7 = MeshCreater.QuadraticCurve1(new Vertex(-1, 57, 1), new Vertex(-1.5, 59, 1.5), new Vertex(0, 61, 0), 0.05);
            Mesh arch8 = MeshCreater.QuadraticCurve1(new Vertex(1, 57, -1), new Vertex(1.5, 59, -1.5), new Vertex(0, 61, 0), 0.05);

            switch (arcCount)
            {
                case 1:
                    vertCount = Verteces.Count;
                    Verteces.AddRange(arch5.Verteces);
                    Faces.AddRange(arch5.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));
                    break;

                case 2:
                    vertCount = Verteces.Count;
                    Verteces.AddRange(arch5.Verteces);
                    Faces.AddRange(arch5.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

                    vertCount = Verteces.Count;
                    Verteces.AddRange(arch6.Verteces);
                    Faces.AddRange(arch6.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));
                    break;

                case 3:
                    vertCount = Verteces.Count;
                    Verteces.AddRange(arch5.Verteces);
                    Faces.AddRange(arch5.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

                    vertCount = Verteces.Count;
                    Verteces.AddRange(arch6.Verteces);
                    Faces.AddRange(arch6.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

                    vertCount = Verteces.Count;
                    Verteces.AddRange(arch7.Verteces);
                    Faces.AddRange(arch7.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));
                    break;

                case 4:
                    vertCount = Verteces.Count;
                    Verteces.AddRange(arch5.Verteces);
                    Faces.AddRange(arch5.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

                    vertCount = Verteces.Count;
                    Verteces.AddRange(arch6.Verteces);
                    Faces.AddRange(arch6.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

                    vertCount = Verteces.Count;
                    Verteces.AddRange(arch7.Verteces);
                    Faces.AddRange(arch7.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));

                    vertCount = Verteces.Count;
                    Verteces.AddRange(arch8.Verteces);
                    Faces.AddRange(arch8.Faces.Select(f => new Face(f.Points[0] + vertCount, f.Points[1] + vertCount, f.Points[2] + vertCount)));
                    break;
            }

        }
    }
}
