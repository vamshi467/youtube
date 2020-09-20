using System.Collections.ObjectModel;
using NewControlsDemo.Models;
using Xamarin.Forms;

namespace NewControlsDemo.Services
{
    public class ImgTransformService 
    {
        public ObservableCollection<ImgTransformModel> GetImagesList()
        {
            return new ObservableCollection<ImgTransformModel>()
            {
                new ImgTransformModel(){ Title = "Blurred Transformation", ImageUrl="https://t4.ftcdn.net/jpg/01/88/79/61/240_F_188796114_Pl86RbwnZz9vnJLcSz0FtBdaPU6DdJes.jpg"},
                new ImgTransformModel(){ Title = "Circle Transformation", ImageUrl="https://t4.ftcdn.net/jpg/01/88/79/61/240_F_188796114_Pl86RbwnZz9vnJLcSz0FtBdaPU6DdJes.jpg"},
                new ImgTransformModel(){ Title = "Rounded Transformation", ImageUrl="https://t4.ftcdn.net/jpg/01/88/79/61/240_F_188796114_Pl86RbwnZz9vnJLcSz0FtBdaPU6DdJes.jpg"},
                new ImgTransformModel(){ Title = "Corners Transformation", ImageUrl="https://t4.ftcdn.net/jpg/01/88/79/61/240_F_188796114_Pl86RbwnZz9vnJLcSz0FtBdaPU6DdJes.jpg"},
                new ImgTransformModel(){ Title = "Crop Transformation", ImageUrl="https://t4.ftcdn.net/jpg/00/73/23/79/240_F_73237971_sA6qmDPEqrQCAAnUHFYUngtnVQr8Hmn0.jpg"},
                new ImgTransformModel(){ Title = "ColorSpace Transformation", ImageUrl="https://t4.ftcdn.net/jpg/00/73/23/79/240_F_73237971_sA6qmDPEqrQCAAnUHFYUngtnVQr8Hmn0.jpg"},
                new ImgTransformModel(){ Title = "Grayscale Transformation", ImageUrl="https://t4.ftcdn.net/jpg/00/73/23/79/240_F_73237971_sA6qmDPEqrQCAAnUHFYUngtnVQr8Hmn0.jpg"},
                new ImgTransformModel(){ Title = "Sepia Transformation", ImageUrl="https://t4.ftcdn.net/jpg/00/73/23/79/240_F_73237971_sA6qmDPEqrQCAAnUHFYUngtnVQr8Hmn0.jpg"},
                new ImgTransformModel(){ Title = "Tint Transformation", ImageUrl="https://t4.ftcdn.net/jpg/00/73/23/79/240_F_73237971_sA6qmDPEqrQCAAnUHFYUngtnVQr8Hmn0.jpg"},
                new ImgTransformModel(){ Title = "Flip Transformation", ImageUrl="https://t4.ftcdn.net/jpg/00/73/23/79/240_F_73237971_sA6qmDPEqrQCAAnUHFYUngtnVQr8Hmn0.jpg"},
                new ImgTransformModel(){ Title = "Rotate Transformation", ImageUrl="https://t4.ftcdn.net/jpg/00/73/23/79/240_F_73237971_sA6qmDPEqrQCAAnUHFYUngtnVQr8Hmn0.jpg"},
            };
        }
    }
}

