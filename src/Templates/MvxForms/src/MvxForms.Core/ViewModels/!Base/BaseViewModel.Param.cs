using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvxForms.Core.ViewModels
{
    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter>
    {
        public abstract void Prepare(TParameter parameter);
    }
}
