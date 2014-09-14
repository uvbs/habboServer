using Cyber.Core;
using Cyber.Messages.Headers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Cyber.Messages.StaticMessageHandlers
{
    internal static class StaticClientMessageHandler
    {
        private delegate void StaticRequestHandler(GameClientMessageHandler handler);

        private static Dictionary<int, StaticRequestHandler> handlers;
        public static void Initialize()
        {
            StaticClientMessageHandler.handlers = new Dictionary<int, StaticClientMessageHandler.StaticRequestHandler>();
            StaticClientMessageHandler.RegisterPacketLibary();
            Logging.WriteLine("Loaded a total of " + StaticClientMessageHandler.handlers.Count + " event handlers.");
        }
        public static void HandlePacket(GameClientMessageHandler handler, ClientMessage message)
        {
            if (StaticClientMessageHandler.handlers.ContainsKey(message.Id))
            {
#if DEBUG
                Logging.WriteLine("Packet id  = " + message.Id, ConsoleColor.Green);
#endif
                StaticClientMessageHandler.StaticRequestHandler staticRequestHandler = StaticClientMessageHandler.handlers[message.Id];
                staticRequestHandler(handler);
                return;
            }
        }
        public static void RegisterPacketLibary()
        {
            handlers.Add(Incoming.InitCryptoMessageEvent, new StaticRequestHandler(SharedPacketLib.InitCrypto));
            handlers.Add(Incoming.GenerateSecretKeyMessageEvent, new StaticRequestHandler(SharedPacketLib.SecretKey));
            handlers.Add(Incoming.UniqueIDMessageEvent, new StaticRequestHandler(SharedPacketLib.MachineId));
            handlers.Add(Incoming.SSOTicketMessageEvent, new StaticRequestHandler(SharedPacketLib.LoginWithTicket));
            handlers.Add(Incoming.InfoRetrieveMessageEvent, new StaticRequestHandler(SharedPacketLib.InfoRetrieve));
            handlers.Add(Incoming.RoomUserActionMessageEvent, new StaticRequestHandler(SharedPacketLib.RoomUserAction));
            handlers.Add(Incoming.RemoveFavouriteRoomMessageEvent, new StaticRequestHandler(SharedPacketLib.RemoveFavouriteRoom));
            handlers.Add(Incoming.UserWhisperMessageEvent, new StaticRequestHandler(SharedPacketLib.Whisper));
            handlers.Add(Incoming.GetCatalogIndexMessageEvent, new StaticRequestHandler(SharedPacketLib.CatalogueIndex));
            handlers.Add(Incoming.GetCatalogPageMessageEvent, new StaticRequestHandler(SharedPacketLib.CataloguePage));
            handlers.Add(Incoming.GetCatalogClubPageMessageEvent, new StaticRequestHandler(SharedPacketLib.CatalogueClubPage));
            handlers.Add(Incoming.GetCatalogOfferMessageEvent, new StaticRequestHandler(SharedPacketLib.CatalogueSingleOffer));
            handlers.Add(Incoming.CatalogueOfferConfigMessageEvent, new StaticRequestHandler(SharedPacketLib.CatalogueOffersConfig));
            handlers.Add(Incoming.CheckPetnameMessageEvent, new StaticRequestHandler(SharedPacketLib.CheckPetName));
            handlers.Add(Incoming.PurchaseFromCatalogMessageEvent, new StaticRequestHandler(SharedPacketLib.PurchaseItem));
            handlers.Add(Incoming.PurchaseFromCatalogAsGiftMessageEvent, new StaticRequestHandler(SharedPacketLib.PurchaseGift));
            handlers.Add(Incoming.GetSellablePetBreedsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetPetBreeds));
            handlers.Add(Incoming.ReloadRecyclerMessageEvent, new StaticRequestHandler(SharedPacketLib.ReloadEcotron));
            handlers.Add(Incoming.GetGiftWrappingConfigurationMessageEvent, new StaticRequestHandler(SharedPacketLib.GiftWrappingConfig));
            handlers.Add(Incoming.GetRecyclerRewardsMessageEvent, new StaticRequestHandler(SharedPacketLib.RecyclerRewards));
            handlers.Add(Incoming.ConfirmLeaveGroupMessageEvent, new StaticRequestHandler(SharedPacketLib.ConfirmLeaveGroup));
            handlers.Add(Incoming.RequestLeaveGroupMessageEvent, new StaticRequestHandler(SharedPacketLib.RequestLeaveGroup));
            handlers.Add(Incoming.NuxReceiveGiftsMessageEvent, new StaticRequestHandler(SharedPacketLib.ReceiveNuxGifts));
            handlers.Add(Incoming.NuxAcceptGiftsMessageEvent, new StaticRequestHandler(SharedPacketLib.AcceptNuxGifts));
            handlers.Add(Incoming.ReadForumThreadMessageEvent, new StaticRequestHandler(SharedPacketLib.ReadForumThread));
            handlers.Add(Incoming.PublishForumThreadMessageEvent, new StaticRequestHandler(SharedPacketLib.PublishForumThread));
            handlers.Add(Incoming.UpdateThreadMessageEvent, new StaticRequestHandler(SharedPacketLib.UpdateForumThread));
            handlers.Add(Incoming.AlterForumThreadStateMessageEvent, new StaticRequestHandler(SharedPacketLib.AlterForumThreadState));
            handlers.Add(Incoming.GetGroupForumThreadRootMessageEvent, new StaticRequestHandler(SharedPacketLib.GetForumThreadRoot));
            handlers.Add(Incoming.GetGroupForumDataMessageEvent, new StaticRequestHandler(SharedPacketLib.GetGroupForumData));
            handlers.Add(Incoming.GetGroupForumsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetGroupForums));
            handlers.Add(Incoming.ChatMessageEvent, new StaticRequestHandler(SharedPacketLib.Chat));
            handlers.Add(Incoming.ShoutMessageEvent, new StaticRequestHandler(SharedPacketLib.Shout));
            handlers.Add(Incoming.GetFloorPlanFurnitureMessageEvent, new StaticRequestHandler(SharedPacketLib.RequestFloorPlanUsedCoords));
            handlers.Add(Incoming.GetFloorPlanDoorMessageEvent, new StaticRequestHandler(SharedPacketLib.RequestFloorPlanDoor));
            handlers.Add(Incoming.SendBullyReportMessageEvent, new StaticRequestHandler(SharedPacketLib.SendBullyReport));
            handlers.Add(Incoming.OpenBullyReportingMessageEvent, new StaticRequestHandler(SharedPacketLib.OpenBullyReporting));
            handlers.Add(Incoming.NavigatorGetPopularGroupsMessageEvent, new StaticRequestHandler(SharedPacketLib.NavigatorGetPopularGroups));
            handlers.Add(Incoming.GetCatalogClubGiftsMessageEvent, new StaticRequestHandler(SharedPacketLib.LoadClubGifts));
            handlers.Add(Incoming.SaveFloorPlanEditorMessageEvent, new StaticRequestHandler(SharedPacketLib.SaveHeightmap));
            handlers.Add(Incoming.RefusePollMessageEvent, new StaticRequestHandler(SharedPacketLib.RefusePoll));
            handlers.Add(Incoming.AnswerPollQuestionMessageEvent, new StaticRequestHandler(SharedPacketLib.AnswerPollQuestion));
            handlers.Add(Incoming.AcceptPollMessageEvent, new StaticRequestHandler(SharedPacketLib.AcceptPoll));
            handlers.Add(Incoming.RetrieveSongIDMessageEvent, new StaticRequestHandler(SharedPacketLib.RetrieveSongID));
            handlers.Add(Incoming.TileStackMagicSetHeightMessageEvent, new StaticRequestHandler(SharedPacketLib.TileStackMagicSetHeight));
            handlers.Add(Incoming.EnableInventoryEffectMessageEvent, new StaticRequestHandler(SharedPacketLib.EnableInventoryEffect));
            handlers.Add(Incoming.PromoteRoomMessageEvent, new StaticRequestHandler(SharedPacketLib.PromoteRoom));
            handlers.Add(Incoming.CatalogPromotionGetRoomsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetPromotionableRooms));
            handlers.Add(Incoming.RoomGetFilterMessageEvent, new StaticRequestHandler(SharedPacketLib.GetRoomFilter));
            handlers.Add(Incoming.RoomAlterFilterMessageEvent, new StaticRequestHandler(SharedPacketLib.AlterRoomFilter));
            handlers.Add(Incoming.YouTubeGetPlayerMessageEvent, new StaticRequestHandler(SharedPacketLib.GetTVPlayer));
            handlers.Add(Incoming.YouTubeChoosePlaylistVideoMessageEvent, new StaticRequestHandler(SharedPacketLib.ChooseTVPlayerVideo));
            handlers.Add(Incoming.YouTubeGetPlaylistGetMessageEvent, new StaticRequestHandler(SharedPacketLib.GetTVPlaylist));
            handlers.Add(Incoming.GetTalentsTrackMessageEvent, new StaticRequestHandler(SharedPacketLib.GetTalentsTrack));
            handlers.Add(Incoming.SendBadgeCampaignMessageEvent, new StaticRequestHandler(SharedPacketLib.PrepareCampaing));
            handlers.Add(Incoming.PongMessageEvent, new StaticRequestHandler(SharedPacketLib.Pong));
            handlers.Add(Incoming.GoToHotelViewMessageEvent, new StaticRequestHandler(SharedPacketLib.ReceptionView));
            handlers.Add(Incoming.LandingRefreshPromosMessageEvent, new StaticRequestHandler(SharedPacketLib.RefreshPromoEvent));
            handlers.Add(Incoming.LandingCommunityGoalMessageEvent, new StaticRequestHandler(SharedPacketLib.LandingCommunityGoal));
            handlers.Add(Incoming.LandingLoadWidgetMessageEvent, new StaticRequestHandler(SharedPacketLib.WidgetContainer));
            handlers.Add(Incoming.OnDisconnectMessageEvent, new StaticRequestHandler(SharedPacketLib.DisconnectEvent));
            handlers.Add(Incoming.LandingRefreshRewardMessageEvent, new StaticRequestHandler(SharedPacketLib.ReceptionView));
            handlers.Add(Incoming.OnlineConfirmationMessageEvent, new StaticRequestHandler(SharedPacketLib.OnlineConfirmationEvent));
            handlers.Add(Incoming.RetrieveCitizenshipStatus, new StaticRequestHandler(SharedPacketLib.RetriveCitizenShipStatus));
            handlers.Add(Incoming.RequestLatencyTestMessageEvent, new StaticRequestHandler(SharedPacketLib.LatencyTest));
            handlers.Add(Incoming.OpenHelpToolMessageEvent, new StaticRequestHandler(SharedPacketLib.InitHelpTool));
            handlers.Add(Incoming.SubmitHelpTicketMessageEvent, new StaticRequestHandler(SharedPacketLib.SubmitHelpTicket));
            handlers.Add(Incoming.RedeemVoucherMessageEvent, new StaticRequestHandler(SharedPacketLib.RedeemVoucher));
            handlers.Add(Incoming.ModerationToolSendRoomAlertMessageEvent, new StaticRequestHandler(SharedPacketLib.ModSendRoomAlert));
            handlers.Add(Incoming.ModerationToolPickIssueMessageEvent, new StaticRequestHandler(SharedPacketLib.ModPickTicket));
            handlers.Add(Incoming.ModerationToolReleaseIssueMessageEvent, new StaticRequestHandler(SharedPacketLib.ModReleaseTicket));
            handlers.Add(Incoming.ModerationToolCloseIssueMessageEvent, new StaticRequestHandler(SharedPacketLib.ModCloseTicket));
            handlers.Add(Incoming.ModerationToolUserToolMessageEvent, new StaticRequestHandler(SharedPacketLib.ModGetUserInfo));
            handlers.Add(Incoming.ModerationToolUserChatlogMessageEvent, new StaticRequestHandler(SharedPacketLib.ModGetUserChatlog));
            handlers.Add(Incoming.ModerationToolRoomChatlogMessageEvent, new StaticRequestHandler(SharedPacketLib.ModGetRoomChatlog));
            handlers.Add(Incoming.ModerationToolGetRoomVisitsMessageEvent, new StaticRequestHandler(SharedPacketLib.ModGetRoomVisits));
            handlers.Add(Incoming.ModerationToolRoomToolMessageEvent, new StaticRequestHandler(SharedPacketLib.ModGetRoomTool));
            handlers.Add(Incoming.ModerationToolPerformRoomActionMessageEvent, new StaticRequestHandler(SharedPacketLib.ModPerformRoomAction));
            handlers.Add(Incoming.ModerationToolSendUserAlertMessageEvent, new StaticRequestHandler(SharedPacketLib.ModSendUserMessage));
            handlers.Add(Incoming.ModerationToolSendUserCautionMessageEvent, new StaticRequestHandler(SharedPacketLib.ModSendUserCaution));
            handlers.Add(Incoming.ModerationKickUserMessageEvent, new StaticRequestHandler(SharedPacketLib.ModKickUser));
            handlers.Add(Incoming.ModerationMuteUserMessageEvent, new StaticRequestHandler(SharedPacketLib.ModMuteUser));
            handlers.Add(Incoming.ModerationLockTradeMessageEvent, new StaticRequestHandler(SharedPacketLib.ModLockTrade));
            handlers.Add(Incoming.ModerationBanUserMessageEvent, new StaticRequestHandler(SharedPacketLib.ModBanUser));
            handlers.Add(Incoming.FriendListUpdateMessageEvent, new StaticRequestHandler(SharedPacketLib.FriendsListUpdate));
            handlers.Add(Incoming.DeleteFriendMessageEvent, new StaticRequestHandler(SharedPacketLib.RemoveBuddy));
            handlers.Add(Incoming.ConsoleSearchFriendsMessageEvent, new StaticRequestHandler(SharedPacketLib.SearchHabbo));
            handlers.Add(Incoming.ConsoleInstantChatMessageEvent, new StaticRequestHandler(SharedPacketLib.SendInstantMessenger));
            handlers.Add(Incoming.AcceptFriendMessageEvent, new StaticRequestHandler(SharedPacketLib.AcceptRequest));
            handlers.Add(Incoming.DeclineFriendMessageEvent, new StaticRequestHandler(SharedPacketLib.DeclineRequest));
            handlers.Add(Incoming.RequestFriendMessageEvent, new StaticRequestHandler(SharedPacketLib.RequestBuddy));
            handlers.Add(Incoming.FollowFriendMessageEvent, new StaticRequestHandler(SharedPacketLib.FollowBuddy));
            handlers.Add(Incoming.ConsoleInviteFriendsMessageEvent, new StaticRequestHandler(SharedPacketLib.SendInstantInvite));
            handlers.Add(Incoming.EnterPrivateRoomMessageEvent, new StaticRequestHandler(SharedPacketLib.OpenFlat));
            handlers.Add(Incoming.AddFavouriteRoomMessageEvent, new StaticRequestHandler(SharedPacketLib.AddFavorite));
            handlers.Add(Incoming.NavigatorGetFlatCategoriesMessageEvent, new StaticRequestHandler(SharedPacketLib.GetFlatCats));
            handlers.Add(Incoming.NavigatorGetFeaturedRoomsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetPubs));
            handlers.Add(Incoming.NavigatorGetPopularRoomsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetPopularRooms));
            handlers.Add(Incoming.NavigatorGetRecommendedRoomsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetRecommendedRooms));
            handlers.Add(Incoming.NavigatorGetHighRatedRoomsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetHighRatedRooms));
            handlers.Add(Incoming.NavigatorGetFriendsRoomsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetFriendsRooms));
            handlers.Add(Incoming.NavigatorGetMyRoomsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetOwnRooms));
            handlers.Add(Incoming.NavigatorGetFavouriteRoomsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetFavoriteRooms));
            handlers.Add(Incoming.NavigatorGetRecentRoomsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetRecentRooms));
            handlers.Add(Incoming.NavigatorGetPopularTagsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetPopularTags));
            handlers.Add(Incoming.NavigatorSearchRoomByNameMessageEvent, new StaticRequestHandler(SharedPacketLib.PerformSearch));
            handlers.Add(Incoming.OpenQuestsMessageEvent, new StaticRequestHandler(SharedPacketLib.OpenQuests));
            handlers.Add(Incoming.QuestStartMessageEvent, new StaticRequestHandler(SharedPacketLib.StartQuest));
            handlers.Add(Incoming.QuestCancelMessageEvent, new StaticRequestHandler(SharedPacketLib.StopQuest));
            handlers.Add(Incoming.LoadNextQuestMessageEvent, new StaticRequestHandler(SharedPacketLib.GetCurrentQuest));
            handlers.Add(Incoming.RoomGetHeightmapMessageEvent, new StaticRequestHandler(SharedPacketLib.GetRoomData2));
            handlers.Add(Incoming.UserWalkMessageEvent, new StaticRequestHandler(SharedPacketLib.Move));
            handlers.Add(Incoming.CanCreateRoomMessageEvent, new StaticRequestHandler(SharedPacketLib.CanCreateRoom));
            handlers.Add(Incoming.CreateRoomMessageEvent, new StaticRequestHandler(SharedPacketLib.CreateRoom));
            handlers.Add(Incoming.RoomGetInfoMessageEvent, new StaticRequestHandler(SharedPacketLib.GetRoomInformation));
            handlers.Add(Incoming.RoomGetSettingsInfoMessageEvent, new StaticRequestHandler(SharedPacketLib.GetRoomEditData));
            handlers.Add(Incoming.RoomSaveSettingsMessageEvent, new StaticRequestHandler(SharedPacketLib.SaveRoomData));
            handlers.Add(Incoming.GiveRightsMessageEvent, new StaticRequestHandler(SharedPacketLib.GiveRights));
            handlers.Add(Incoming.RoomRemoveUserRightsMessageEvent, new StaticRequestHandler(SharedPacketLib.TakeRights));
            handlers.Add(Incoming.RoomRemoveAllRightsMessageEvent, new StaticRequestHandler(SharedPacketLib.TakeAllRights));
            handlers.Add(Incoming.RoomKickUserMessageEvent, new StaticRequestHandler(SharedPacketLib.KickUser));
            handlers.Add(Incoming.RoomBanUserMessageEvent, new StaticRequestHandler(SharedPacketLib.BanUser));
            handlers.Add(Incoming.TradeStartMessageEvent, new StaticRequestHandler(SharedPacketLib.InitTrade));
            handlers.Add(Incoming.SetHomeRoomMessageEvent, new StaticRequestHandler(SharedPacketLib.SetHomeRoom));
            handlers.Add(Incoming.RoomDeleteMessageEvent, new StaticRequestHandler(SharedPacketLib.DeleteRoom));
            handlers.Add(Incoming.LookAtUserMessageEvent, new StaticRequestHandler(SharedPacketLib.LookAt));
            handlers.Add(Incoming.StartTypingMessageEvent, new StaticRequestHandler(SharedPacketLib.StartTyping));
            handlers.Add(Incoming.StopTypingMessageEvent, new StaticRequestHandler(SharedPacketLib.StopTyping));
            handlers.Add(Incoming.IgnoreUserMessageEvent, new StaticRequestHandler(SharedPacketLib.IgnoreUser));
            handlers.Add(Incoming.UnignoreUserMessageEvent, new StaticRequestHandler(SharedPacketLib.UnignoreUser));
            handlers.Add(Incoming.UserSignMessageEvent, new StaticRequestHandler(SharedPacketLib.Sign));
            handlers.Add(Incoming.GetUserTagsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetUserTags));
            handlers.Add(Incoming.GetUserBadgesMessageEvent, new StaticRequestHandler(SharedPacketLib.GetUserBadges));
            handlers.Add(Incoming.RateRoomMessageEvent, new StaticRequestHandler(SharedPacketLib.RateRoom));
            handlers.Add(Incoming.UserDanceMessageEvent, new StaticRequestHandler(SharedPacketLib.Dance));
            handlers.Add(Incoming.DropHanditemMessageEvent, new StaticRequestHandler(SharedPacketLib.RemoveHanditem));
            handlers.Add(Incoming.GiveHanditemMessageEvent, new StaticRequestHandler(SharedPacketLib.GiveHanditem));
            handlers.Add(Incoming.DoorbellAnswerMessageEvent, new StaticRequestHandler(SharedPacketLib.AnswerDoorbell));
            handlers.Add(Incoming.RoomLoadByDoorbellMessageEvent, new StaticRequestHandler(SharedPacketLib.ReqLoadRoomForUser));
            handlers.Add(Incoming.RoomApplySpaceMessageEvent, new StaticRequestHandler(SharedPacketLib.ApplyRoomEffect));
            handlers.Add(Incoming.RoomAddFloorItemMessageEvent, new StaticRequestHandler(SharedPacketLib.PlaceItem));
            handlers.Add(Incoming.PickUpItemMessageEvent, new StaticRequestHandler(SharedPacketLib.TakeItem));
            handlers.Add(Incoming.FloorItemMoveMessageEvent, new StaticRequestHandler(SharedPacketLib.MoveItem));
            handlers.Add(Incoming.WallItemMoveMessageEvent, new StaticRequestHandler(SharedPacketLib.MoveWallItem));
            handlers.Add(Incoming.TriggerItemMessageEvent, new StaticRequestHandler(SharedPacketLib.TriggerItem));
            handlers.Add(Incoming.UseHabboWheelMessageEvent, new StaticRequestHandler(SharedPacketLib.TriggerItem));
            handlers.Add(Incoming.TriggerWallItemMessageEvent, new StaticRequestHandler(SharedPacketLib.TriggerItem));
            handlers.Add(Incoming.OpenPostItMessageEvent, new StaticRequestHandler(SharedPacketLib.OpenPostit));
            handlers.Add(Incoming.SavePostItMessageEvent, new StaticRequestHandler(SharedPacketLib.SavePostit));
            handlers.Add(Incoming.SaveClientSettingsMessageEvent, new StaticRequestHandler(SharedPacketLib.SaveVolume));
            handlers.Add(Incoming.RemovePostItMessageEvent, new StaticRequestHandler(SharedPacketLib.DeletePostit));
            handlers.Add(Incoming.OpenGiftMessageEvent, new StaticRequestHandler(SharedPacketLib.OpenPresent));
            handlers.Add(Incoming.ActivateMoodlightMessageEvent, new StaticRequestHandler(SharedPacketLib.GetMoodlight));
            handlers.Add(Incoming.UpdateMoodlightMessageEvent, new StaticRequestHandler(SharedPacketLib.UpdateMoodlight));
            handlers.Add(Incoming.TriggerMoodlightMessageEvent, new StaticRequestHandler(SharedPacketLib.SwitchMoodlightStatus));
            handlers.Add(Incoming.TradeAddItemOfferMessageEvent, new StaticRequestHandler(SharedPacketLib.OfferTradeItem));
            handlers.Add(Incoming.TradeRemoveItemMessageEvent, new StaticRequestHandler(SharedPacketLib.TakeBackTradeItem));
            handlers.Add(Incoming.TradeCancelMessageEvent, new StaticRequestHandler(SharedPacketLib.StopTrade));
            handlers.Add(Incoming.TradeDiscardMessageEvent, new StaticRequestHandler(SharedPacketLib.StopTrade));
            handlers.Add(Incoming.TradeAcceptMessageEvent, new StaticRequestHandler(SharedPacketLib.AcceptTrade));
            handlers.Add(Incoming.TradeUnacceptMessageEvent, new StaticRequestHandler(SharedPacketLib.UnacceptTrade));
            handlers.Add(Incoming.TradeConfirmMessageEvent, new StaticRequestHandler(SharedPacketLib.CompleteTrade));
            handlers.Add(Incoming.GiveRespectMessageEvent, new StaticRequestHandler(SharedPacketLib.GiveRespect));
            handlers.Add(Incoming.EffectEnableMessageEvent, new StaticRequestHandler(SharedPacketLib.EnableEffect));
            handlers.Add(Incoming.EnterOneWayDoorMessageEvent, new StaticRequestHandler(SharedPacketLib.TriggerItem));
            handlers.Add(Incoming.TriggerDiceCloseMessageEvent, new StaticRequestHandler(SharedPacketLib.TriggerItemDiceSpecial));
            handlers.Add(Incoming.TriggerDiceRollMessageEvent, new StaticRequestHandler(SharedPacketLib.TriggerItem));
            handlers.Add(Incoming.EcotronRecycleMessageEvent, new StaticRequestHandler(SharedPacketLib.RecycleItems));
            handlers.Add(Incoming.BotSpeechListMessageEvent, new StaticRequestHandler(SharedPacketLib.HandleBotSpeechList));
            handlers.Add(Incoming.ReedemExchangeItemMessageEvent, new StaticRequestHandler(SharedPacketLib.RedeemExchangeFurni));
            handlers.Add(Incoming.PlacePetMessageEvent, new StaticRequestHandler(SharedPacketLib.PlacePet));
            handlers.Add(Incoming.PetGetInformationMessageEvent, new StaticRequestHandler(SharedPacketLib.GetPetInfo));
            handlers.Add(Incoming.PickUpPetMessageEvent, new StaticRequestHandler(SharedPacketLib.PickUpPet));
            handlers.Add(Incoming.RespectPetMessageEvent, new StaticRequestHandler(SharedPacketLib.RespectPet));
            //handlers.Add(Incoming.MovePetMessageEvent, new StaticRequestHandler(SharedPacketLib.MovePet));
            //handlers.Add(Incoming.CompostMonsterplantMessageEvent, new StaticRequestHandler(SharedPacketLib.CompostMonsterplant));
            handlers.Add(Incoming.RoomAddPostItMessageEvent, new StaticRequestHandler(SharedPacketLib.PlacePostIt));
            handlers.Add(Incoming.HorseAddSaddleMessageEvent, new StaticRequestHandler(SharedPacketLib.AddSaddle));
            handlers.Add(Incoming.HorseRemoveSaddleMessageEvent, new StaticRequestHandler(SharedPacketLib.RemoveSaddle));
            handlers.Add(Incoming.HorseMountOnMessageEvent, new StaticRequestHandler(SharedPacketLib.Ride));
            handlers.Add(Incoming.UserGetVolumeSettingsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetVoume));
            handlers.Add(Incoming.WiredSaveEffectMessageEvent, new StaticRequestHandler(SharedPacketLib.SaveWired));
            handlers.Add(Incoming.WiredSaveTriggerMessageEvent, new StaticRequestHandler(SharedPacketLib.SaveWired));
            handlers.Add(Incoming.WiredSaveMatchingMessageEvent, new StaticRequestHandler(SharedPacketLib.SaveWired));
            handlers.Add(Incoming.WiredSaveConditionMessageEvent, new StaticRequestHandler(SharedPacketLib.SaveWiredCondition));
            handlers.Add(Incoming.GetMusicDataMessageEvent, new StaticRequestHandler(SharedPacketLib.GetMusicData));
            handlers.Add(Incoming.JukeboxAddPlaylistItemMessageEvent, new StaticRequestHandler(SharedPacketLib.AddPlaylistItem));
            handlers.Add(Incoming.JukeboxRemoveSongMessageEvent, new StaticRequestHandler(SharedPacketLib.RemovePlaylistItem));
            handlers.Add(Incoming.LoadJukeboxDiscsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetDisks));
            handlers.Add(Incoming.GetJukeboxPlaylistsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetPlaylists));
            handlers.Add(Incoming.LoadUserProfileMessageEvent, new StaticRequestHandler(SharedPacketLib.LoadProfile));
            handlers.Add(Incoming.GetCurrencyBalanceMessageEvent, new StaticRequestHandler(SharedPacketLib.GetBalance));
            handlers.Add(Incoming.GetSubscriptionDataMessageEvent, new StaticRequestHandler(SharedPacketLib.GetSubscriptionData));
            handlers.Add(Incoming.LoadBadgeInventoryMessageEvent, new StaticRequestHandler(SharedPacketLib.GetBadges));
            handlers.Add(Incoming.SetActivatedBadgesMessageEvent, new StaticRequestHandler(SharedPacketLib.UpdateBadges));
            handlers.Add(Incoming.OpenAchievementsBoxMessageEvent, new StaticRequestHandler(SharedPacketLib.GetAchievements));
            handlers.Add(Incoming.UserUpdateLookMessageEvent, new StaticRequestHandler(SharedPacketLib.ChangeLook));
            handlers.Add(Incoming.UserUpdateMottoMessageEvent, new StaticRequestHandler(SharedPacketLib.ChangeMotto));
            handlers.Add(Incoming.WardrobeMessageEvent, new StaticRequestHandler(SharedPacketLib.GetWardrobe));
            handlers.Add(Incoming.WardrobeUpdateMessageEvent, new StaticRequestHandler(SharedPacketLib.SaveWardrobe));
            handlers.Add(Incoming.LoadItemsInventoryMessageEvent, new StaticRequestHandler(SharedPacketLib.GetInventory));
            handlers.Add(Incoming.LoadPetInventoryMessageEvent, new StaticRequestHandler(SharedPacketLib.GetPetsInventory));
            handlers.Add(Incoming.HorseAllowAllRideMessageEvent, new StaticRequestHandler(SharedPacketLib.AllowAllRide));
            handlers.Add(Incoming.SaveRoomBrandingMessageEvent, new StaticRequestHandler(SharedPacketLib.SaveBranding));
            handlers.Add(Incoming.LoadBotInventoryMessageEvent, new StaticRequestHandler(SharedPacketLib.GetBotInv));
            handlers.Add(Incoming.PlaceBotMessageEvent, new StaticRequestHandler(SharedPacketLib.PlaceBot));
            handlers.Add(Incoming.SaveRoomBackgroundTonerMessageEvent, new StaticRequestHandler(SharedPacketLib.SaveRoomBg));
            handlers.Add(Incoming.ToggleSittingMessageEvent, new StaticRequestHandler(SharedPacketLib.Sit));
            handlers.Add(Incoming.PickUpBotMessageEvent, new StaticRequestHandler(SharedPacketLib.PickUpBot));
            handlers.Add(Incoming.NavigatorGetEventsMessageEvent, new StaticRequestHandler(SharedPacketLib.GetEventRooms));
            handlers.Add(Incoming.QuestSeasonalStartMessageEvent, new StaticRequestHandler(SharedPacketLib.StartSeasonalQuest));
            handlers.Add(Incoming.MannequinSaveDataMessageEvent, new StaticRequestHandler(SharedPacketLib.SaveMannequin));
            handlers.Add(Incoming.MannequinUpdateDataMessageEvent, new StaticRequestHandler(SharedPacketLib.SaveMannequin2));
            handlers.Add(Incoming.GetGroupPurchaseBoxMessageEvent, new StaticRequestHandler(SharedPacketLib.SerializeGroupPurchasePage));
            handlers.Add(Incoming.GetGroupPurchasingInfoMessageEvent, new StaticRequestHandler(SharedPacketLib.SerializeGroupPurchaseParts));
            handlers.Add(Incoming.CreateGuildMessageEvent, new StaticRequestHandler(SharedPacketLib.PurchaseGroup));
            handlers.Add(Incoming.GetGroupInfoMessageEvent, new StaticRequestHandler(SharedPacketLib.SerializeGroupInfo));
            handlers.Add(Incoming.GetGroupMembersMessageEvent, new StaticRequestHandler(SharedPacketLib.SerializeGroupMembers));
            handlers.Add(Incoming.GroupMakeAdministratorMessageEvent, new StaticRequestHandler(SharedPacketLib.MakeGroupAdmin));
            handlers.Add(Incoming.RemoveGroupAdminMessageEvent, new StaticRequestHandler(SharedPacketLib.RemoveGroupAdmin));
            handlers.Add(Incoming.AcceptGroupRequestMessageEvent, new StaticRequestHandler(SharedPacketLib.AcceptMembership));
            handlers.Add(Incoming.GroupDeclineMembershipRequestMessageEvent, new StaticRequestHandler(SharedPacketLib.DeclineMembership));
            handlers.Add(Incoming.GroupUserJoinMessageEvent, new StaticRequestHandler(SharedPacketLib.JoinGroup));
            handlers.Add(Incoming.SetFavoriteGroupMessageEvent, new StaticRequestHandler(SharedPacketLib.MakeFav));
            handlers.Add(Incoming.RemoveFavouriteGroupMessageEvent, new StaticRequestHandler(SharedPacketLib.RemoveFav));
            handlers.Add(Incoming.GroupManageMessageEvent, new StaticRequestHandler(SharedPacketLib.ManageGroup));
            handlers.Add(Incoming.GroupUpdateNameMessageEvent, new StaticRequestHandler(SharedPacketLib.UpdateGroupName));
            handlers.Add(Incoming.GroupUpdateSettingsMessageEvent, new StaticRequestHandler(SharedPacketLib.UpdateGroupSettings));
            handlers.Add(Incoming.GroupUpdateColoursMessageEvent, new StaticRequestHandler(SharedPacketLib.UpdateGroupColours));
            handlers.Add(Incoming.GroupUpdateBadgeMessageEvent, new StaticRequestHandler(SharedPacketLib.UpdateGroupBadge));
            handlers.Add(Incoming.GetGroupFurnitureMessageEvent, new StaticRequestHandler(SharedPacketLib.SerializeGroupFurniPage));
            handlers.Add(Incoming.RoomSettingsMuteUserMessageEvent, new StaticRequestHandler(SharedPacketLib.MuteUser));
            handlers.Add(Incoming.ChangeUsernameMessageEvent, new StaticRequestHandler(SharedPacketLib.ChangeName));
            handlers.Add(Incoming.CheckUsernameMessageEvent, new StaticRequestHandler(SharedPacketLib.CheckName));
            handlers.Add(Incoming.GetPetTrainerPanelMessageEvent, new StaticRequestHandler(SharedPacketLib.GetTrainerPanel));
            handlers.Add(Incoming.RoomEventUpdateMessageEvent, new StaticRequestHandler(SharedPacketLib.UpdateEventInfo));
            handlers.Add(Incoming.GetRoomBannedUsersMessageEvent, new StaticRequestHandler(SharedPacketLib.GetRoomBannedUsers));
            handlers.Add(Incoming.RoomUnbanUserMessageEvent, new StaticRequestHandler(SharedPacketLib.UnbanUser));
            handlers.Add(Incoming.BotActionsMessageEvent, new StaticRequestHandler(SharedPacketLib.ManageBotActions));
            handlers.Add(Incoming.RelationshipsGetMessageEvent, new StaticRequestHandler(SharedPacketLib.GetRelationships));
            handlers.Add(Incoming.SetRelationshipMessageEvent, new StaticRequestHandler(SharedPacketLib.SetRelationship));
            handlers.Add(Incoming.RoomOnLoadMessageEvent, new StaticRequestHandler(SharedPacketLib.AutoRoom));
            handlers.Add(Incoming.RoomSettingsMuteAllMessageEvent, new StaticRequestHandler(SharedPacketLib.MuteAll));
            handlers.Add(Incoming.GetRoomRightsListMessageEvent, new StaticRequestHandler(SharedPacketLib.UsersWithRights));
            handlers.Add(Incoming.CompleteSafetyQuizMessageEvent, new StaticRequestHandler(SharedPacketLib.CompleteSafteyQuiz));
            handlers.Add(Incoming.SaveFootballGateOutfitMessageEvent, new StaticRequestHandler(SharedPacketLib.SaveFootballOutfit));
            //handlers.Add(Incoming.ConfirmLoveLockMessageEvent, new StaticRequestHandler(SharedPacketLib.ConfirmLoveLock));

        }
    }
}
