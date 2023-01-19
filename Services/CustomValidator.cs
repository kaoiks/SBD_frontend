using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BS.Forms.ValidatorComponent.Components
{

    public class CustomValidator : ComponentBase
    {
        private ValidationMessageStore messageStore;
        [CascadingParameter]
        public EditContext CurrentEditContext { get; set; }

        protected override void OnInitialized()
        {
            if (CurrentEditContext == null)
            {
                throw new InvalidOperationException("To use validator component your razor page should have the edit component");
            }
            messageStore = new ValidationMessageStore(CurrentEditContext);
            CurrentEditContext.OnValidationRequested += (s, e) => messageStore.Clear();
            CurrentEditContext.OnFieldChanged += (s, e) => messageStore.Clear(e.FieldIdentifier);


        }

        public void DisplayErrors(Dictionary<string, List<string>> errors)
        {
            foreach (var error in errors)
            {
                messageStore.Add(CurrentEditContext.Field(error.Key), error.Value);
            }
            CurrentEditContext.NotifyValidationStateChanged();
        }
    }
}
