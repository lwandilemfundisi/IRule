﻿using XRule.Extensions;
using XRule.Notifications;
using Microservice.Framework.Common;

namespace XRule.Validations.Common
{
    public abstract class AlphaPropertyValidation<T>
        : Validation<T> where T : class
    {
        #region Virtual Methods

        protected override Task<Notification> OnValidate(CancellationToken cancellationToken)
        {
            var notification = Notification.CreateEmpty();

            var propertyValue = PropertyValue.AsString();

            if (propertyValue.IsNotNullOrEmpty())
            {
                if (!StringValidationHelper.ValidateString(propertyValue, AllowedCharacter.Alpha))
                {
                    notification.AddMessage(OnCreateMessage());
                }
            }

            return Task.FromResult(notification);
        }

        protected virtual Message OnCreateMessage()
        {
            return CreateMessage("{0} may only contain alpha characters", DisplayName);
        }

        #endregion
    }
}
