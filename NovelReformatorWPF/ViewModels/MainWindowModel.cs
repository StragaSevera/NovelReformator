using System.Windows.Input;
using NovelReformatorWPF.Models;
using NovelReformatorWPF.ViewModels.Commands;

namespace NovelReformatorWPF.ViewModels
{
    public class MainWindowModel : BaseViewModel
    {
        private string _request;

        public string Request
        {
            get => _request;
            set => SetProperty(ref _request, value);
        }

        private string _response;

        public string Response
        {
            get => _response;
            set => SetProperty(ref _response, value);
        }

        public ICommand SendRequest { get; }

        private readonly RequestSender _requestSender;

        public MainWindowModel()
        {
            _requestSender = new RequestSender();
            SendRequest = new RelayCommand(OnSendRequest);
        }

        private void OnSendRequest(object o)
        {
            Response = _requestSender.SendRequest(Request);
        }
    }
}