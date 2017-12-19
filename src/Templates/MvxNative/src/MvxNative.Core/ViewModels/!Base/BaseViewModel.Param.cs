using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.Platform;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MvxNative.Core.ViewModels
{
    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter>
    {
        public async Task Init(string parameter)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                if (!Mvx.TryResolve(out IMvxJsonConverter serializer))
                {
                    throw new MvxIoCResolveException($"There is no implementation of {nameof(IMvxJsonConverter)} registered. You need to use the MvvmCross Json plugin or create your own implementation of {nameof(IMvxJsonConverter)}.");
                }

                TParameter deserialized = serializer.DeserializeObject<TParameter>(parameter);
                Prepare(deserialized);
                await Initialize();
            }
        }

        public abstract void Prepare(TParameter parameter);
    }
}
