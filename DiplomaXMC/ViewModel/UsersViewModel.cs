using DiplomaXMC.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;

namespace DiplomaXMC.ViewModel
{
    public class UsersViewModel
    {
        ObservableCollection<XMCUsers> _users;
        //public ObservableCollection<XMCUsers> Users
        //{
        //    get
        //    {
        //        using (var client = new HttpClient())
        //        {
        //            var uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/Pozicion/GetAllPositions";
        //            var result =  client.GetStringAsync(uri);
        //            var ResultList = JsonConvert.DeserializeObject<List<XMCUsers>>(result);
        //            return new ObservableCollection<XMCUsers>(ResultList);
        //        }
        //    }
        //    set
        //    {
        //        _users = value;
        //    }
        //}

        //public async void GetUsers()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        var uri = "http://diplomaxmcws-dev.us-east-2.elasticbeanstalk.com/api/Pozicion/GetAllPositions";
        //        var result = await  client.GetStringAsync(uri);
        //        var ResultList = JsonConvert.DeserializeObject<List<XMCUsers>>(result);
        //        _users =  ObservableCollection<XMCUsers>(ResultList);
        //    }
        //}
    }
}
