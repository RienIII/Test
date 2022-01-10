[V] Create BookStore db, Members table �إ߸�ƪ�
[V] Create NTUB.BookStore.Site MVC project �إ�MVC�M��

[V] Add /Models/ViewModels/RegisterVM.cs �إ� Register ViewModels �o�O View �n�Ϊ�
[V] Create "MembersController", with "Register" action, and View Page 
	�إߪťժ� Controller �̭��g�J�@�� �W�٬� Register �� Action(Method)�A���k��إ��˵��A"��Ƥ��e���O"�i�H���ο�(�g)
[V] ���� NuGet�M��̭��� �c��y���]�A�n�O�o�ظm�M�סA���M�|�����~

[V] Add /Models/UseCases/RegisterRequest, RegisterResponse class 
[V] Add /Models/Entities/RegisterEntity class 
[V] Add /Models/UseCases/RegisterCommand class (with Execute method)
[V] Add /Models/Core/MemberService class (with CreateNewMember method)
[V] implement MemberController.Register function ��@ MemberController �̭����Ƶ{�� Register
[V] implement RegisterCommand.Execute function ��@ RegisterCommand �̭����Ƶ{�� Execute

[V] Add /Models/Infrastructures/Repositories/MemberRepository

ActiveRegister?memberId=11&confirmCode=0fb7a7840a754fedb66e7cc3f5464d19

-- �s�|��Email�T�{�\�� --
[V] �|�����UEmail�̭����s���AMemberController.ConfirmRegister()�AService.ActiveRegister
[V] modfiy�վ�W�[��ӥ\�� IMemberRepository.Lord(int memberId)return MemberEntity, ActiveRegister(int memberId)return void
[V] Views/Members/ConfirmRegister

-- Password�s�X --
[V] Add /Models/Infrastructures/HashUtility.cs
[V] �ק�MemberEntity�AAdd EnctryptedPassword property
[V] �ק�MemberRepository�A��s�J���K�X���� EnctryptedPassword
[V] �ק� Members Table, column Password, from nvarchar(50) to nvarchar(70)
[V] �P�B�ק� /Models/EFModels/Members.cs �̭��� Password data annotation

-- �n�J/�n�X���� --
[V] modfiy web.config, Add Authentication node
[V] modfiy MembersController.About, Add "Authorize" attribute
[V] Add MembersController.Logout()
[V] /Models/ViewModels/LoginVM.cs
[V] Add MembersController.Login(), and Create "Login" view page
[V] /Models/DTOs/LoginResponse.cs
[V] Add MemberRepository.Login(string account)
[V] Add MemberService.Login(string account, string password)
[V] Add MemberController.Login() HttpPost action
	�ϥΪ��{�ҡA�g�J cookie
[V] modfiy _Layout page, Add "Login/Logout" Links

-- �|������ -- 
[V] �|�����߭�(/Members/Indes/)
	��web.config
	add MembersController.Index(), Index View page
[V] �ק�ӤH�򥻸��(/Members/EditProfile)
[V] �ܧ�K�X(/Members/ResetPassword)

** �ק�ӤH�򥻸��
[V] add /ViewModels/EditProfileVM.cs
[V] add MembersController.EditProfile(), add "EditProfile" view page
[V] add UpdateProfileRequest class, add MemberService.UpdateProfile(UpdateProfileRequest)
	UpdateProfileRequest class �[�J string "CurrentUserAccount" property
[V] modify IMemberRepository => add IsExists(account, excludeId), Update(MemberEntity)
[V] �p�G��s�Ӹꦨ�\�A�B����b���A�N�۰���� Login page

-- �إ߸�ƪ� --

...

-- BookStoreBackEnd��x --
[V] �s�W��x���� "BookStore.BackEnd.Site"�A�Ŀ� Web.API
[V] �b��x�������s�إ� /Models/EFModels/

[working on] �ϥ�²�������{�ҡA�N�b�K�g�b Web.config ��
[working on] ��@�n�J/�n�X�\��F�u�n���n�J�N��ϥΫ�x�Ҧ��\��
				add /Models/ViewModels/LoginVM.cs
				add HomeController.Login(), Logout()
				add Login, Logout View pages
				�ק� password control
				�ק� _Layout page navbar
				�ק� [Authorize]
