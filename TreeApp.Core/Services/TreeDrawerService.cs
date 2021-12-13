using System;
using System.Drawing;

using TreeApp.Core.Models;

namespace TreeApp.Core.Services
{
    public static class TreeDrawerService
    {
        public static Bitmap DrawTree(TreeModel tree, int imageWidth, int imageHeight)
        {
            var bitmap = new Bitmap(imageWidth, imageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using var graphics = Graphics.FromImage(bitmap);

            var size = Math.Min(imageWidth, imageHeight);
            var pixelHeight = size / tree.Height;

            DrawFoundation(graphics, imageWidth, imageHeight, pixelHeight, tree);
            DrawBranches(graphics, imageWidth, imageHeight, pixelHeight, tree);

            return bitmap;
        }

        private static void DrawFoundation(Graphics graph, int imageWidth, int imageHeight, double pixelHeight, TreeModel tree)
        {
            //  thichness - толщина ствола в основании
            var thichness = TreeCalculator.GetThickness(tree.Height);

            var treeWidth = pixelHeight * thichness;

            var startX = (imageWidth - treeWidth) / 2;

            var treeHeight = tree.Height * pixelHeight;

            var leftDown = new PointF((float)startX, imageHeight);
            var rightDown = new PointF((float)(startX + treeWidth), imageHeight);
            var top = new PointF((imageWidth - 1) / 2.0f, (float)(imageHeight - treeHeight));

            var triangle = new PointF[] { leftDown, rightDown, top };

            graph.DrawPolygon(Pens.Brown, triangle);
            graph.FillPolygon(Brushes.Brown, triangle);
        }

        private static void DrawBranches(Graphics graphics, int imageWidth, int imageHeight, double pixelHeight, TreeModel tree)
        {
            //  ширина дерева, в см
            var treeWidth = TreeCalculator.GetWidth(tree.Height, tree.Seed);

            //  начало веток, в см
            var startHeight = TreeCalculator.GetStartHeight(tree.Height);

            //  количество веток
            var branches = TreeCalculator.GetBranchCount(tree.Height, tree.Seed);

            //  высота треугольника с ветками
            var triangleHeight = (tree.Height - startHeight) / branches;

            var angle = (tree.Height - startHeight) / treeWidth;

            for (var branch = 0; branch < branches; branch++)
            {
                var currentHeight = (tree.Height - startHeight) - branch * triangleHeight;

                var width = currentHeight / angle;

                var pixelWidth = width * pixelHeight;
                var pixelTreeHeight = imageHeight - startHeight * pixelHeight - branch * triangleHeight * pixelHeight;

                var left = new PointF((float)((imageWidth - pixelWidth) / 2), (float)pixelTreeHeight);
                var right = new PointF(left.X + (float)pixelWidth, (float)pixelTreeHeight);

                var top = new PointF(imageWidth / 2.0f, (float)(pixelTreeHeight - triangleHeight * pixelHeight));

                var triangle = new PointF[] { left, right, top };

                graphics.DrawPolygon(Pens.Green, triangle);
                graphics.FillPolygon(Brushes.Green, triangle);
            }
        }
    }
}
