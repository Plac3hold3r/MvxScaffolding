using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.ViewModels;

namespace MvxFormsTemp.Core.ViewModels
{
    public abstract class BaseViewModel<TParameter, TResult> : BaseViewModelResult<TResult>, IMvxViewModel<TParameter, TResult>
        where TParameter : class
        where TResult : class
    {
        public abstract void Prepare(TParameter parameter);
    }
}
