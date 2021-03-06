﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMSWCFService.DataContracts;
using System.ServiceModel;

namespace PMSWCFService.ServiceContracts
{
    /// <summary>
    /// 全面的客户信息服务
    /// 用户管理类型客户端
    /// </summary>
    [ServiceContract]
    public interface IUserAccessService
    {
        [OperationContract]
        List<DcUser> GetAllUsers();
        [OperationContract]
        List<DcUserRole> GetAllRoles();
        [OperationContract]
        List<DcUserAccess> GetAllAccesses();

        [OperationContract]
        bool IsUserNameExsit(string userName);
        [OperationContract]
        DcUser GetUser(string username, string password);
        [OperationContract]
        DcUserRole GetRole(Guid roleId);
        [OperationContract]
        List<DcUserAccess> GetAccesses(Guid roleId);

        [OperationContract]
        int AddUser(DcUser model);
        [OperationContract]
        int AddRole(DcUserRole model);
        [OperationContract]
        int AddAccess(DcUserAccess model);

        [OperationContract]
        int UpdateUser(DcUser model);
        [OperationContract]
        int UpdateRole(DcUserRole model);
        [OperationContract]
        int UpdateAccess(DcUserAccess model);

        [OperationContract]
        int DeleteUser(Guid id);
        [OperationContract]
        int DeleteRole(Guid id);
        [OperationContract]
        int DeleteAccess(Guid id);

    }
}