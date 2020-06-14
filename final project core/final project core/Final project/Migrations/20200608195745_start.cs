using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_project.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    address = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    birth_date = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    BioInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "catagories",
                columns: table => new
                {
                    cat_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat_Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_catagories", x => x.cat_Id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    type_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.type_id);
                });

            migrationBuilder.CreateTable(
                name: "seasons",
                columns: table => new
                {
                    season_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    season_name = table.Column<string>(nullable: true),
                    start_time = table.Column<string>(nullable: true),
                    period = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seasons", x => x.season_id);
                });

            migrationBuilder.CreateTable(
                name: "venBudgets",
                columns: table => new
                {
                    catt_id = table.Column<int>(nullable: false),
                    vendor_id = table.Column<string>(nullable: false),
                    Cat_budget = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venBudgets", x => new { x.vendor_id, x.catt_id });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "connections",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    connectionId = table.Column<string>(nullable: true),
                    userid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_connections", x => x.id);
                    table.ForeignKey(
                        name: "FK_connections_AspNetUsers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mess_Text = table.Column<string>(maxLength: 500, nullable: false),
                    Replay = table.Column<string>(nullable: true),
                    Vendor_id = table.Column<string>(nullable: true),
                    User_id = table.Column<string>(nullable: true),
                    Date_Send = table.Column<DateTime>(nullable: false),
                    Date_replay = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_messages_AspNetUsers_User_id",
                        column: x => x.User_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_messages_AspNetUsers_Vendor_id",
                        column: x => x.Vendor_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "toDo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vendor_Id = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toDo", x => x.id);
                    table.ForeignKey(
                        name: "FK_toDo_AspNetUsers_Vendor_Id",
                        column: x => x.Vendor_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userProducts",
                columns: table => new
                {
                    piece_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userseller_id = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: false),
                    piece_Cost = table.Column<int>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    piece_description = table.Column<string>(nullable: false),
                    publish_date = table.Column<DateTime>(nullable: false),
                    available_date = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userProducts", x => x.piece_id);
                    table.ForeignKey(
                        name: "FK_userProducts_AspNetUsers_userseller_id",
                        column: x => x.userseller_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupname = table.Column<string>(nullable: true),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userSelleds",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userseller_id = table.Column<string>(nullable: true),
                    userbuyer_id = table.Column<string>(nullable: true),
                    user_used = table.Column<int>(nullable: false),
                    cost = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userSelleds", x => x.ID);
                    table.ForeignKey(
                        name: "FK_userSelleds_AspNetUsers_userbuyer_id",
                        column: x => x.userbuyer_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userSelleds_AspNetUsers_userseller_id",
                        column: x => x.userseller_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vendorWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    category_id = table.Column<int>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: false),
                    vendor_id = table.Column<string>(nullable: true),
                    last_updated = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendorWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vendorWorks_AspNetUsers_vendor_id",
                        column: x => x.vendor_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Article_Title = table.Column<string>(maxLength: 50, nullable: false),
                    Article_Description = table.Column<string>(maxLength: 1000, nullable: false),
                    PostDate = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    CatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_articles_catagories_CatId",
                        column: x => x.CatId,
                        principalTable: "catagories",
                        principalColumn: "cat_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_articles_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "favorits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(nullable: true),
                    vendor_id = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    vendor_Name = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    about = table.Column<string>(nullable: true),
                    cat_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_favorits_catagories_cat_id",
                        column: x => x.cat_id,
                        principalTable: "catagories",
                        principalColumn: "cat_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_favorits_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_favorits_AspNetUsers_vendor_id",
                        column: x => x.vendor_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Rate = table.Column<int>(nullable: false),
                    User_Id = table.Column<string>(nullable: true),
                    Vendor_Id = table.Column<string>(nullable: true),
                    Category_Id = table.Column<int>(nullable: false),
                    catagorycat_Id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ratings_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratings_AspNetUsers_Vendor_Id",
                        column: x => x.Vendor_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratings_catagories_catagorycat_Id",
                        column: x => x.catagorycat_Id,
                        principalTable: "catagories",
                        principalColumn: "cat_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(maxLength: 250, nullable: false),
                    User_Id = table.Column<string>(nullable: true),
                    Vendor_Id = table.Column<string>(nullable: true),
                    catagory_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_reviews_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reviews_AspNetUsers_Vendor_Id",
                        column: x => x.Vendor_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reviews_catagories_catagory_id",
                        column: x => x.catagory_id,
                        principalTable: "catagories",
                        principalColumn: "cat_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Website = table.Column<string>(nullable: false),
                    FacebookLink = table.Column<string>(nullable: true),
                    Twitterr = table.Column<string>(nullable: true),
                    Instgram = table.Column<string>(nullable: true),
                    PersonalImage = table.Column<string>(nullable: false),
                    catt_id = table.Column<int>(nullable: false),
                    vendor_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vendors_catagories_catt_id",
                        column: x => x.catt_id,
                        principalTable: "catagories",
                        principalColumn: "cat_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vendors_AspNetUsers_vendor_id",
                        column: x => x.vendor_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    old_price = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    product_image = table.Column<string>(nullable: true),
                    type_id = table.Column<int>(nullable: false),
                    Exp_date = table.Column<DateTime>(nullable: false),
                    Prod_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_products_ProductTypes_type_id",
                        column: x => x.type_id,
                        principalTable: "ProductTypes",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "packages",
                columns: table => new
                {
                    PackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    feature_name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    catagory_id = table.Column<int>(nullable: false),
                    season_id = table.Column<int>(nullable: true),
                    Event_id = table.Column<int>(nullable: true),
                    status = table.Column<bool>(nullable: false),
                    PackageCost = table.Column<int>(nullable: false),
                    VendorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_packages", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_packages_events_Event_id",
                        column: x => x.Event_id,
                        principalTable: "events",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_packages_AspNetUsers_VendorId",
                        column: x => x.VendorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_packages_catagories_catagory_id",
                        column: x => x.catagory_id,
                        principalTable: "catagories",
                        principalColumn: "cat_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_packages_seasons_season_id",
                        column: x => x.season_id,
                        principalTable: "seasons",
                        principalColumn: "season_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "review_Replays",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review_Id = table.Column<int>(nullable: false),
                    PostDate = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(maxLength: 250, nullable: false),
                    User_Id = table.Column<string>(nullable: true),
                    Vendor_Id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review_Replays", x => x.ID);
                    table.ForeignKey(
                        name: "FK_review_Replays_reviews_Review_Id",
                        column: x => x.Review_Id,
                        principalTable: "reviews",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_review_Replays_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_review_Replays_AspNetUsers_Vendor_Id",
                        column: x => x.Vendor_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(nullable: false),
                    user_id = table.Column<string>(nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<int>(nullable: false),
                    state = table.Column<bool>(nullable: false),
                    shop_time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.id);
                    table.ForeignKey(
                        name: "FK_Shops_products_product_id",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shops_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookDate = table.Column<DateTime>(nullable: false),
                    RealDate = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    VendorId = table.Column<string>(nullable: true),
                    pack_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_booking_catagories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "catagories",
                        principalColumn: "cat_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_booking_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_booking_AspNetUsers_VendorId",
                        column: x => x.VendorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_booking_packages_pack_id",
                        column: x => x.pack_id,
                        principalTable: "packages",
                        principalColumn: "PackageId");
                });

            migrationBuilder.CreateTable(
                name: "vendorBusies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vendor_id = table.Column<string>(nullable: true),
                    BookingId = table.Column<int>(nullable: true),
                    BusyDay = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendorBusies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vendorBusies_booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "booking",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vendorBusies_AspNetUsers_vendor_id",
                        column: x => x.vendor_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_articles_CatId",
                table: "articles",
                column: "CatId");

            migrationBuilder.CreateIndex(
                name: "IX_articles_user_id",
                table: "articles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_booking_CategoryId",
                table: "booking",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_booking_UserId",
                table: "booking",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_booking_VendorId",
                table: "booking",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_booking_pack_id",
                table: "booking",
                column: "pack_id");

            migrationBuilder.CreateIndex(
                name: "IX_connections_userid",
                table: "connections",
                column: "userid",
                unique: true,
                filter: "[userid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_favorits_cat_id",
                table: "favorits",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_favorits_user_id",
                table: "favorits",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_favorits_vendor_id",
                table: "favorits",
                column: "vendor_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_User_id",
                table: "messages",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_messages_Vendor_id",
                table: "messages",
                column: "Vendor_id");

            migrationBuilder.CreateIndex(
                name: "IX_packages_Event_id",
                table: "packages",
                column: "Event_id");

            migrationBuilder.CreateIndex(
                name: "IX_packages_VendorId",
                table: "packages",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_packages_catagory_id",
                table: "packages",
                column: "catagory_id");

            migrationBuilder.CreateIndex(
                name: "IX_packages_season_id",
                table: "packages",
                column: "season_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_type_id",
                table: "products",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_User_Id",
                table: "ratings",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_Vendor_Id",
                table: "ratings",
                column: "Vendor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_catagorycat_Id",
                table: "ratings",
                column: "catagorycat_Id");

            migrationBuilder.CreateIndex(
                name: "IX_review_Replays_Review_Id",
                table: "review_Replays",
                column: "Review_Id");

            migrationBuilder.CreateIndex(
                name: "IX_review_Replays_User_Id",
                table: "review_Replays",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_review_Replays_Vendor_Id",
                table: "review_Replays",
                column: "Vendor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_User_Id",
                table: "reviews",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_Vendor_Id",
                table: "reviews",
                column: "Vendor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_catagory_id",
                table: "reviews",
                column: "catagory_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_product_id",
                table: "Shops",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_user_id",
                table: "Shops",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_toDo_Vendor_Id",
                table: "toDo",
                column: "Vendor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_userProducts_userseller_id",
                table: "userProducts",
                column: "userseller_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_userId",
                table: "users",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_userSelleds_userbuyer_id",
                table: "userSelleds",
                column: "userbuyer_id");

            migrationBuilder.CreateIndex(
                name: "IX_userSelleds_userseller_id",
                table: "userSelleds",
                column: "userseller_id");

            migrationBuilder.CreateIndex(
                name: "IX_vendorBusies_BookingId",
                table: "vendorBusies",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_vendorBusies_vendor_id",
                table: "vendorBusies",
                column: "vendor_id");

            migrationBuilder.CreateIndex(
                name: "IX_vendors_catt_id",
                table: "vendors",
                column: "catt_id");

            migrationBuilder.CreateIndex(
                name: "IX_vendors_vendor_id",
                table: "vendors",
                column: "vendor_id");

            migrationBuilder.CreateIndex(
                name: "IX_vendorWorks_vendor_id",
                table: "vendorWorks",
                column: "vendor_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "connections");

            migrationBuilder.DropTable(
                name: "favorits");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "review_Replays");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "toDo");

            migrationBuilder.DropTable(
                name: "userProducts");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "userSelleds");

            migrationBuilder.DropTable(
                name: "venBudgets");

            migrationBuilder.DropTable(
                name: "vendorBusies");

            migrationBuilder.DropTable(
                name: "vendors");

            migrationBuilder.DropTable(
                name: "vendorWorks");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "packages");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "catagories");

            migrationBuilder.DropTable(
                name: "seasons");
        }
    }
}
