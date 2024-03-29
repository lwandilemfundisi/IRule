﻿using XRule.Extensions;
using XRule.Notifications;
using Microservice.Framework.Common;

namespace XRule.Validations.Common
{
    public abstract class BasicInputValidation<T>
        : Validation<T> where T : class
    {
        #region Virtual Methods

        protected override Task<Notification> OnValidate(CancellationToken cancellationToken)
        {
            var notification = Notification.CreateEmpty();

            var propertyValue = PropertyValue.AsString();

            if (propertyValue.IsNotNullOrEmpty())
            {
                if (!StringValidationHelper.ValidateString(propertyValue, OnGetAllowedCharacterTypes().ToArray()))
                {
                    notification.AddMessage(OnCreateMessage());
                }
            }

            return Task.FromResult(notification);
        }

        protected virtual Message OnCreateMessage()
        {
            return CreateMessage("{0} must be alphanumeric", DisplayName);
        }

        protected virtual IEnumerable<AllowedCharacter> OnGetAllowedCharacterTypes()
        {
            return new AllowedCharacter[]
            {
                AllowedCharacter.Alpha,
                AllowedCharacter.Numeric,
                AllowedCharacter.Space,
                AllowedCharacter.Dot,
                AllowedCharacter.Comma,
                AllowedCharacter.ForwardSlash
            };
        }

        #endregion
    }
}
