using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;

namespace MvxFormsTemp.Core.ViewModels
{
    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter>
        where TParameter : class
    {
        public abstract void Prepare(TParameter parameter);
    }
}
