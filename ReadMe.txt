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

-- -- --

[V] add ProductService...
				rebuild EFModels
				add /Models/Entities/CategoryEntity
				add /Models/Entities/ProductEntity
				add /Models/Core/Interfaces/IProductRepository
				add /Models/Core/Services/ProductService

[V] add StockService...
				add /Models/DTOs/DeductStockInfo(�n�������w�s�q��T) : ProductID, Qty(�ƶq���O����)
				add /Models/DTOs/ReviseStockInfo(�����q��ɭn�W�[�w�s�q��T) : ProductID, Qty(����)
				add /Models/Core/Interfaces/IStockService
				add /Models/Core/Interfaces/IStockRepository
				add /Models/Core/StockService

[V] add CustomerService...
				add CustomerEntity
				add ICustomerRepository
				add CustomerService

[V] add CartService...
				add CartProductEntity
				add CartItemEntity
				add ShippingInfo(value, object)
				add CartEntity
				add ICartRepository

				add CreateOrderItem(DTO)
				add CreateOrderRequest(DTO)
				add ICartService
				add CartService

[V] add OrderService...
				add OrderProductEntity
				add OrderItemEntity
				add OrderEntity
				add IOrderRepository
				add IOrderService
				add OrderService : IOrderService
				
[V] add /Models/Core/CartMediator.cs

[V] add Repository...
				add ProductRepository 
					add ProductExts.ToEntity()

				add CustomerRepository
					add MemberExts.ToCustomerEntity()

				add StockRepository

				add CartRepository
					add ProductExts.ToProductEntity() in ProductExts.cs
					add CartItemExts.ToItemEntity()
					add CartExts.ToEntity()
					add CartEntityExts.ToEF()
					add CartItemEntityExts.ToEF()

				add OrderRepository
					add CreateOrderItemExts.ToEF()
					add CreateOrderRequestExts.ToEF()
					add OrderItemExts.ToEntity()
					add ProductExts.ToOrderProductEntity()
					add OrderExts.ToShippingInfo()
					add OrderExts.ToEntity()

[working on] �ӫ~�M�歶�A��ܦh���ӫ~�A�i�[�J�ʪ���
				ProductsController.Index
				add ProductVM
				modify IProductService.Search
				�ϥ�jQuery�A���U Button click�A���o product id