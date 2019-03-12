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
            private set
            {
                _request = value;
                OnPropertyChanged();
            }
        }

        private string _response;

        public string Response
        {
            get => _response;
            set
            {
                _response = value;
                OnPropertyChanged();
            }
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
            _response = _requestSender.SendRequest(_request);
        }
    }
}