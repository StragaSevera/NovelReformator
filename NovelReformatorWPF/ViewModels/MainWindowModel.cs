using System.Windows.Input;
using NovelReformatorWPF.Models;
using NovelReformatorWPF.ViewModels.Commands;

namespace NovelReformatorWPF.ViewModels
{
    public class MainWindowModel : BaseViewModel
    {
        private readonly RequestSender _requestSender;
        private string _request;

        private string _response;

        public MainWindowModel()
        {
            _requestSender = new RequestSender();
            SendRequest = new RelayCommand(OnSendRequest);
        }

        public string Request
        {
            get => _request;
            set => SetProperty(ref _request, value);
        }

        public string Response
        {
            get => _response;
            set => SetProperty(ref _response, value);
        }

        public ICommand SendRequest { get; }

        private void OnSendRequest(object o)
        {
            Response = _requestSender.SendRequest(Request);
        }
    }
}