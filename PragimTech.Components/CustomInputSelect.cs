using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PragimTech.Components
{
    public class CustomInputSelect<TValue> : InputSelect<TValue>
    {
        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            if (typeof(TValue) == typeof(int))
            {
                if (int.TryParse(value, out var resultInt))
                {
                    result = (TValue)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = $"The selected valie {value} is not a valid number";
                    return false;

                }
            }
            else if (typeof(TValue) == typeof(Guid))
            {
                if (Guid.TryParse(value, out var resultGuid))
                {
                    result = (TValue)(object)resultGuid;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = $"The selected valie {value} is not a valid Guid";
                    return false;
                }
            }
            else
            {
                return base.TryParseValueFromString(value, out result, out validationErrorMessage);
            }
        }
    }
}
