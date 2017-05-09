using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLOCart.Domain.BusinessServiceContracts;
using GLOCart.Domain.DataAccessContracts;
using GLOCart.Domain;
using GLOCart.Domain.Repository;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Configuration;
using GLOCart.Domain.Helper;
using AutoMapper;

namespace GLOCart.BusinessServices.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IPageRoleMappingRepository _pageRoleMappingRepository;
        private readonly IUnitOfWork _unitofwork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitofwork, ILocationRepository locationRepository, IPageRoleMappingRepository pageRoleMappingRepository)
        {
            _userRepository = userRepository;
            _unitofwork = unitofwork;
            _locationRepository = locationRepository;
            _pageRoleMappingRepository = pageRoleMappingRepository;
            CreateGLOUserMapping();
        }

        public User GetUserInfo(string userName, string GLOToken)
        {
            User userObj = null;
            var gloObj =  GetDetailsFromGLO(userName, GLOToken);//.Result;
            if (gloObj != null)
            {
                userObj = Mapper.Map<GLOUser, User>(gloObj);
                userObj.LocationId = _locationRepository.GetAllByKey("Name", gloObj.location).First().Id;
                var userInfoLocal = GetUserFromDB(userName);
                if(userInfoLocal != null)
                    userObj.RoleType = userInfoLocal.RoleType;
                else
                    userObj.RoleType = RoleType.User;
                return userObj;
            }
            else
                return null;
        }

        public IEnumerable<User> SearchUsers(string searchUser, RoleType roletype, string GLOTokenKey = null)
        {
            List<User> listUser = new List<User>();
            if (roletype == RoleType.User)
            {
                var glolist = Search(searchUser, GLOTokenKey).Result;
                foreach (var glouser in glolist)
                {
                    listUser.Add(Mapper.Map<GLOUser, User>(glouser));
                }
                return listUser;
            }
            else
            {
                var experts = GetAllExperts(roletype);
                return experts.Where(x => x.DisplayName.Contains(searchUser));
            }
        }

        public User GetUserFromDB(string userName)
        {
            return _userRepository.GetByKey(userName);
        }

        public User AddExpert(User user)
        {
            throw new NotImplementedException();
        }

        public User DeleteExpert(string userName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllExperts(RoleType roletype)
        {
           return _userRepository.GetAllByKey("RoleType", (int)roletype);
        }

        public void UpdateExpert(User user)
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public async Task<string> AuthenticateUser(string credentials)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["GLOApiBaseURI"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials); 

                var response = await client.GetAsync(ConfigurationManager.AppSettings["GLOCart.AppKey"] + "/gloapis/login.js");
                var tokenObj = response.Content.ReadAsStringAsync().Result.DeserializeJson<GLOAppToken>();
                // var userObj = JsonHelper.DeserializeJson<User>(response);

                response.EnsureSuccessStatusCode();
                return tokenObj.App_Token;
            }
        }

        public User CheckUserExistence(string userName, string GLOToken)
        {
          //  var count = _userRepository.Count("where \"LogonName\" = @0", userName);
            User userObj = null;
            userObj = _userRepository.GetByKey(userName);
            if (userObj == null)
            {
                var gloObj = GetDetailsFromGLO(userName, GLOToken);
              //  var gloObj = Obj.Result;    
                if (gloObj != null)
                {
                    userObj = Mapper.Map<GLOUser, User>(gloObj);
                    userObj.LocationId = _locationRepository.GetAllByKey("Name", gloObj.location).First().Id;
                    userObj.RoleType = RoleType.User;
                    return userObj;
                }
                else
                    return null;
            }
            else
                return userObj;
        }

        private void CreateGLOUserMapping()
        {
            Mapper.CreateMap<GLOUser, User>()
                .ForMember(dest => dest.Login, src => src.MapFrom(x => x.login))
                .ForMember(dest => dest.DisplayName, src => src.MapFrom(x => x.displayname))
                .ForMember(dest => dest.FirstName, src => src.MapFrom(x => x.firstname))
                .ForMember(dest => dest.LastName, src => src.MapFrom(x => x.lastname))
                .ForMember(dest => dest.Email, src => src.MapFrom(x => x.email))
                .ForMember(dest => dest.TinyAvatar, src => src.MapFrom(x => x.tiny_avatar))
                .ForMember(dest => dest.SmallAvatar, src => src.MapFrom(x => x.small_avatar))
                .ForMember(dest => dest.Ecode, src => src.MapFrom(x => x.ecode))
                .ForMember(dest => dest.Designation, src => src.MapFrom(x => x.designation))
                .ForMember(dest => dest.RoleType, src => src.MapFrom(x => x.RoleType));
        }
        

        private GLOUser GetDetailsFromGLO(string userName, string GLOToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["GLOApiBaseURI"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = client.GetAsync(ConfigurationManager.AppSettings["GLOCart.AppKey"] + "/" + GLOToken + "/gloapis/" + userName + "/get_user_info_by_login.js");
                var userObj = response.Result.Content.ReadAsStringAsync().Result.DeserializeJson<GLOUser>();
                // var userObj = JsonHelper.DeserializeJson<User>(response);

                response.Result.EnsureSuccessStatusCode();
                return userObj;
            }

        }

        private async Task<IEnumerable<GLOUser>> Search(string searchText, string GLOToken)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["GLOApiBaseURI"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(ConfigurationManager.AppSettings["GLOCart.AppKey"] + "/" + GLOToken + "/gloapis/" + searchText + "/search_user.js");
                var userObj = response.Content.ReadAsStringAsync().Result.DeserializeJson<IEnumerable<GLOUser>>();
                // var userObj = JsonHelper.DeserializeJson<User>(response);
                response.EnsureSuccessStatusCode();
                return userObj;
            }
        }


        public bool HasPermissions(string viewname, RoleType roletype)
        {
           return _pageRoleMappingRepository.Query("Where LOWER(\"ViewName\") = LOWER(@0) and \"RoleID\" = @1", viewname, (int)roletype).Count() != 0 ? true : false;           
        }


        public List<string> GetViewPermissionList(int roleType)
        {
            return _pageRoleMappingRepository.GetAllByKey("RoleID", roleType).Select(x =>x.ViewName).ToList();
        }
    }
}
