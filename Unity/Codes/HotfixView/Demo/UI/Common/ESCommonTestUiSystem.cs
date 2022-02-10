namespace ET
{
    public static class ESCommonTestUiSystem
    {
        public static void SetLable(this ESCommonTestUi self, string message)
        {
            self.ELableText.text = message;
        }
    }
}