using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace learn.Views
{
	public partial class Login : ContentPage
	{
		public Login()
		{
			InitializeComponent();
		}

		private void Paint_RoundRect_withoutBorder(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
		{
			SKImageInfo info = args.Info;
			SKSurface surface = args.Surface;
			SKCanvas canvas = surface.Canvas;

			canvas.Clear();

			using (SKPaint paint = new SKPaint())
			{

				var radius = info.Height / 2;
				SKRect rect;

				//half of the strokewidth to get border inside is added to left-top and subtracted from bottom-right
				rect = new SKRect(info.Rect.Left, info.Rect.Top, info.Rect.Right, info.Rect.Bottom);

				SKColor borderColor = ((Color)Application.Current.Resources["ButtonBackgroundColor"]).ToSKColor();
				paint.Color = borderColor;
				//paint.StrokeWidth = 5;
				//paint.Style = SKPaintStyle.Stroke;
				paint.IsAntialias = true;
				paint.Style = SKPaintStyle.Fill;



				canvas.DrawRoundRect(rect, radius, radius, paint);
				//canvas.DrawColor(borderColor, SKBlendMode.ColorDodge);
			}

		}

		private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
		{
			SKImageInfo info = args.Info;
			SKSurface surface = args.Surface;
			SKCanvas canvas = surface.Canvas;

			canvas.Clear();

			using (SKPaint paint = new SKPaint())
			{
				// define the color for the shadow

				SKColor shadowColor = ((Color)Application.Current.Resources["ButtonBackgroundColor"]).ToSKColor();

				paint.IsDither = true;
				paint.IsAntialias = true;
				paint.Color = shadowColor;

				// create filter for drop shadow
				paint.ImageFilter = SKImageFilter.CreateDropShadow(
					dx: 0, dy: 0,
					sigmaX: 40, sigmaY: 40,
					color: shadowColor,
					shadowMode: SKDropShadowImageFilterShadowMode.DrawShadowOnly);

				// define where I want to draw the object
				var margin = info.Width / 10;
				var shadowBounds = new SKRect(margin, -40, info.Width - margin, 10);
				canvas.DrawRoundRect(shadowBounds, 10, 10, paint);

			}

		}

		private void Paint_RoundRect_withBorder(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs args)
		{
			SKImageInfo info = args.Info;
			SKSurface surface = args.Surface;
			SKCanvas canvas = surface.Canvas;

			canvas.Clear();

			using (SKPaint paint = new SKPaint())
			{

				var radius = info.Height / 2;
				SKRect rect;

				//half of the strokewidth to get border inside is added to left-top and subtracted from bottom-right
				rect = new SKRect(info.Rect.Left + 3, info.Rect.Top + 3, info.Rect.Right - 3, info.Rect.Bottom - 3);

				SKColor borderColor = ((Color)Application.Current.Resources["FontColor"]).ToSKColor();
				paint.Color = borderColor;
				paint.StrokeWidth = 5;
				paint.Style = SKPaintStyle.Stroke;
				paint.IsAntialias = true;



				canvas.DrawRoundRect(rect, radius, radius, paint);

			}

		}

	}
}
