﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;
using Smartpool.Connection.Model;
using Smartpool.Connection.Server.FakePoolDataGeneration;

namespace Smartpool.Connection.Server
{
    public class TokenMsgResponse : ITokenMsgResponse
    {
        // ReSharper disable once CollectionNeverQueried.Local -> _fakePools never used since they write directly to db
        private readonly List<FakePool> _fakePools = new List<FakePool>();
        private readonly Random _random = new Random();
        private readonly ISmartpoolDB _smartpoolDb;
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
        public TokenMsgResponse(ISmartpoolDB smartpoolDb)
        {
            _smartpoolDb = smartpoolDb;
            var poolList = _smartpoolDb.PoolAccess.FindAllPoolsOfUser("1");
            foreach (var pool in poolList)
            {
                _fakePools.Add(new FakePool(4, 15, "1", pool.Name, _smartpoolDb));
                Thread.Sleep(1100);
            }
        }

        public Message HandleTokenMsg(Message message, string messageString, ITokenKeeper tokenKeeper)
        {
            var tokenMsg = JsonConvert.DeserializeObject<TokenMsg>(messageString, _jsonSettings);
            switch (tokenMsg.SubMsgType)
            {
                //Pool messages
                case TokenSubMessageTypes.AddPoolRequest:
                    var apMsg = JsonConvert.DeserializeObject<AddPoolRequestMsg>(messageString);
                    var poolCreatedSuccessfully = _smartpoolDb.PoolAccess.AddPool(apMsg.Username, apMsg.Name,
                        apMsg.Volume);
                    _fakePools.Add(new FakePool(4, 15, apMsg.Username, apMsg.Name, _smartpoolDb));
                    return new GeneralResponseMsg(true, poolCreatedSuccessfully); 

                case TokenSubMessageTypes.UpdatePoolRequest:
                    var upMsg = JsonConvert.DeserializeObject<UpdatePoolRequestMsg>(messageString);
                    var newNameSuccess = true;
                    var newVolumeSuccess = true;
                    if (upMsg.NewPoolName != "")
                    {
                        newNameSuccess = _smartpoolDb.PoolAccess.EditPoolName(upMsg.Username, upMsg.OldPoolName, upMsg.NewPoolName);
                    }
                    if (upMsg.NewPoolVolume != 0)
                    {
                        newVolumeSuccess = _smartpoolDb.PoolAccess.EditPoolVolume(upMsg.Username, upMsg.OldPoolName, upMsg.NewPoolVolume);
                    }
                    if (newVolumeSuccess && newNameSuccess)
                    return new GeneralResponseMsg(true, true);
                    else
                    {
                        return new GeneralResponseMsg(true, false) {MessageInfo = "An error happened. Data was not saved"};
                    }

                case TokenSubMessageTypes.RemovePoolRequest:
                    var rpMsg = JsonConvert.DeserializeObject<RemovePoolRequestMsg>(messageString);
                    return new GeneralResponseMsg(true, _smartpoolDb.PoolAccess.RemovePool(rpMsg.Username, rpMsg.PoolName)); 

                case TokenSubMessageTypes.AddPoolPictureRequest:
                    var appMsg = JsonConvert.DeserializeObject<AddPoolPictureRequestMsg>(messageString);
                    return new GeneralResponseMsg(true, false) { MessageInfo = "Not implemented" };

                case TokenSubMessageTypes.GetPoolDataRequest:
                    var gpdMsg = JsonConvert.DeserializeObject<GetPoolDataRequestMsg>(messageString);
                    if (gpdMsg.GetAllNamesOnly)
                    {
                        var pools = _smartpoolDb.PoolAccess.FindAllPoolsOfUser(gpdMsg.Username);
                        var poolNamesListTuple =
                            pools.Select(pool => Tuple.Create(pool.Name, _random.NextDouble() > 0.5)).ToList();
                        return new GetPoolDataResponseMsg() {AllPoolNamesListTuple = poolNamesListTuple};
                    }
                    else //return data for one pool only
                        //return new GetPoolDataResponseMsg(GetSensorValues(gpdMsg.Username, gpdMsg.PoolName, gpdMsg.GetHistoryDays));
                        return new GetPoolDataResponseMsg(_fakePools[0].GetSensorValuesList());

                case TokenSubMessageTypes.GetPoolInfoRequest:
                    var gpiMsg = JsonConvert.DeserializeObject<GetPoolInfoRequestMsg>(messageString);
                    var poolToReturn = _smartpoolDb.PoolAccess.FindSpecificPool(gpiMsg.Username, gpiMsg.PoolName);
                    return new GetPoolInfoResponseMsg(poolToReturn.Volume, "GTP8H-H8D8D-DDTKD-MT8W6-PTD6M");

                //User messages
                case TokenSubMessageTypes.ChangePasswordRequest:
                    var cpMsg = JsonConvert.DeserializeObject<ChangePasswordRequestMsg>(messageString);
                    return new GeneralResponseMsg(true, _smartpoolDb.UserAccess.EditUserPassword(cpMsg.Username, cpMsg.NewPassword));

                case TokenSubMessageTypes.LogoutRequest:
                    var loMsg = JsonConvert.DeserializeObject<LogoutRequestMsg>(messageString);
                    tokenKeeper.RemoveToken(loMsg.Username);
                    return new GeneralResponseMsg(true, true);
                
                case TokenSubMessageTypes.AllowAccessToPoolDataRequest:
                    return new GeneralResponseMsg(true, false) {MessageInfo = "Not implemented"};
                //Monitor unit messages
                case TokenSubMessageTypes.ChangeSensorTargetValueRequest:
                    return new GeneralResponseMsg(true, false) { MessageInfo = "Not implemented" };
                //Default
                default:
                    return new GeneralResponseMsg(true, false);
            }
        }

        private List<Tuple<SensorTypes, List<double>>> GetSensorValues(string userName, string poolName, int days)
        {
            return new List<Tuple<SensorTypes, List<double>>>
            {
                GetData(_smartpoolDb.DataAccess.GetTemperatureValues(userName, poolName, days), SensorTypes.Temperature),
                GetData(_smartpoolDb.DataAccess.GetPhValues(userName, poolName, days), SensorTypes.Ph),
                GetData(_smartpoolDb.DataAccess.GetChlorineValues(userName, poolName, days), SensorTypes.Chlorine),
                GetData(_smartpoolDb.DataAccess.GetHumidityValues(userName, poolName, days), SensorTypes.Humidity)
            };
        }

        private static Tuple<SensorTypes, List<double>> GetData(List<Tuple<SensorTypes, double>> dataFromDb, SensorTypes sensorType)
        {
            var tempList = new List<double>();
            foreach (var tuple in dataFromDb)
            {
                tempList.Add(tuple.Item2);
            }
            return new Tuple<SensorTypes, List<double>>(sensorType, tempList);
        }
    }
}