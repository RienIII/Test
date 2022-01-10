[V] Create BookStore db, Members table 建立資料表
[V] Create NTUB.BookStore.Site MVC project 建立MVC專案

[V] Add /Models/ViewModels/RegisterVM.cs 建立 Register ViewModels 這是 View 要用的
[V] Create "MembersController", with "Register" action, and View Page 
	建立空白的 Controller 裡面寫入一個 名稱為 Register 的 Action(Method)，按右鍵建立檢視，"資料內容類別"可以不用選(寫)
[V] 移除 NuGet套件裡面的 繁體語言包，要記得建置專案，不然會有錯誤

[V] Add /Models/UseCases/RegisterRequest, RegisterResponse class 
[V] Add /Models/Entities/RegisterEntity class 
[V] Add /Models/UseCases/RegisterCommand class (with Execute method)
[V] Add /Models/Core/MemberService class (with CreateNewMember method)
[V] implement MemberController.Register function 實作 MemberController 裡面的副程式 Register
[V] implement RegisterCommand.Execute function 實作 RegisterCommand 裡面的副程式 Execute

[V] Add /Models/Infrastructures/Repositories/MemberRepository

ActiveRegister?memberId=11&confirmCode=0fb7a7840a754fedb66e7cc3f5464d19

-- 新會員Email確認功能 --
[V] 會員按下Email裡面的連結，MemberController.ConfirmRegister()，Service.ActiveRegister
[V] modfiy調整增加兩個功能 IMemberRepository.Lord(int memberId)return MemberEntity, ActiveRegister(int memberId)return void
[V] Views/Members/ConfirmRegister

-- Password編碼 --
[V] Add /Models/Infrastructures/HashUtility.cs
[V] 修改MemberEntity，Add EnctryptedPassword property
[V] 修改MemberRepository，把存入的密碼換成 EnctryptedPassword
[V] 修改 Members Table, column Password, from nvarchar(50) to nvarchar(70)
[V] 同步修改 /Models/EFModels/Members.cs 裡面的 Password data annotation

-- 登入/登出網站 --
[V] modfiy web.config, Add Authentication node
[V] modfiy MembersController.About, Add "Authorize" attribute
[V] Add MembersController.Logout()
[V] /Models/ViewModels/LoginVM.cs
[V] Add MembersController.Login(), and Create "Login" view page
[V] /Models/DTOs/LoginResponse.cs
[V] Add MemberRepository.Login(string account)
[V] Add MemberService.Login(string account, string password)
[V] Add MemberController.Login() HttpPost action
	使用表單認證，寫入 cookie
[V] modfiy _Layout page, Add "Login/Logout" Links

-- 會員中心 -- 
[V] 會員中心頁(/Members/Indes/)
	改web.config
	add MembersController.Index(), Index View page
[V] 修改個人基本資料(/Members/EditProfile)
[V] 變更密碼(/Members/ResetPassword)

** 修改個人基本資料
[V] add /ViewModels/EditProfileVM.cs
[V] add MembersController.EditProfile(), add "EditProfile" view page
[V] add UpdateProfileRequest class, add MemberService.UpdateProfile(UpdateProfileRequest)
	UpdateProfileRequest class 加入 string "CurrentUserAccount" property
[V] modify IMemberRepository => add IsExists(account, excludeId), Update(MemberEntity)
[V] 如果更新個資成功，且有改帳號，就自動轉到 Login page

-- 建立資料表 --

...

-- BookStoreBackEnd後台 --
[V] 新增後台網站 "BookStore.BackEnd.Site"，勾選 Web.API
[V] 在後台網站重新建立 /Models/EFModels/

[working on] 使用簡易的表單認證，將帳密寫在 Web.config 中
[working on] 實作登入/登出功能；只要有登入就能使用後台所有功能
				add /Models/ViewModels/LoginVM.cs
				add HomeController.Login(), Logout()
				add Login, Logout View pages
				修改 password control
				修改 _Layout page navbar
				修改 [Authorize]
