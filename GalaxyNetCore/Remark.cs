using static System.Net.Mime.MediaTypeNames;

namespace GalaxyNetCore
{
    public class Remark
    {
        ///在分层架构（Layered Architecture）或领域驱动设计（Domain-Driven Design, DDD）的背景下，常见的项目分层如下：
        // Domain 层（领域层）
        // Application 层（应用层）
        // Infrastructure 层（基础设施层）
        /// Presentation 层（表示层，通常为 Web API 或前端应用）
        #region 概述
        //1.GalaxyNetCore.Api（表示层/呈现层）
        //引用：
        //GalaxyNetCore.Application（应用层）
        //GalaxyNetCore.Infrastructure（基础设施层）

        //2.GalaxyNetCore.Application（应用层）
        //引用：
        //GalaxyNetCore.Domain（领域层）

        //3.GalaxyNetCore.Infrastructure（基础设施层）
        //引用：
        //GalaxyNetCore.Application（应用层）
        //GalaxyNetCore.Domain（领域层）

        //GalaxyNetCore.Domain：
        //核心业务实体和领域逻辑。
        //定义业务对象（实体、值对象）和业务规则。
        //GalaxyNetCore.Application：

        //定义应用服务和用例。
        //包含接口、DTOs、业务服务等。
        //协调 Domain 层和 Infrastructure 层的交互。
        //GalaxyNetCore.Infrastructure：

        //实现应用层定义的接口。
        //处理具体的技术实现，如数据访问、外部服务集成。
        //包含仓储实现、数据库上下文等。
        #endregion

        #region 项目结构
        //│  project_tree.txt                        # 目录结构文件
        //│  README.md                               # 项目说明文档
        //│  
        //├─.github
        //│  └─workflows                             # GitHub Actions 工作流配置
        //│
        //├─GalaxyNetCore.WebApi                     # Web API 项目（表示层）
        //│  │  GalaxyNetCore.WebApi.csproj           # Web API 项目文件
        //│  │  Program.cs                            # 应用启动入口
        //│  │  appsettings.json                      # 应用配置文件
        //│  │  appsettings.Development.json          # 开发环境配置文件
        //│  │  GalaxyNetCore.http                     # 可选，用于HTTP测试（如Postman Collection）
        //│  │  Remark.cs                              # 示例或占位文件
        //│  │  WeatherForecast.cs                     # 示例控制器文件
        //│  │  
        //│  ├─.vs                                   # Visual Studio 配置文件（自动生成，通常忽略）
        //│  ├─bin                                   # 编译输出文件夹（通常忽略）
        //│  ├─Controllers                           # Web API 控制器
        //│  │      MarketDataController.cs          # 处理MarketData相关请求的控制器
        //│  │      WeatherForecastController.cs      # 示例控制器（可删除或替换为实际业务控制器）
        //│  │      
        //│  ├─Filters                               # 请求过滤器（如认证、日志等）
        //│  │      Remark.cs                          # 示例或占位文件
        //│  │      
        //│  ├─Middlewares                           # 中间件（如异常处理、日志记录等）
        //│  │      Remark.cs                          # 示例或占位文件
        //│  │      
        //│  ├─obj                                   # 编译中间文件夹（通常忽略）
        //│  └─Properties
        //│          launchSettings.json             # 本地启动配置
        //│          
        //├─GalaxyNetCore.Application                # 应用层
        //│  │  GalaxyNetCore.Application.csproj      # 应用层项目文件
        //│  │  Remark.cs                              # 示例或占位文件
        //│  │  
        //│  ├─Admin                                 # 后台管理模块（示例，待开发）
        //│  │      # 未来可添加与用户管理相关的服务、DTOs等
        //│  │  
        //│  ├─Shared                                # 应用层共享资源
        //│  │  ├─CommonServices                     # 公共应用服务
        //│  │  │      DependencyInjection.cs        # 应用层依赖注入配置扩展方法
        //│  │  │      
        //│  │  ├─Interfaces                          # 通用接口
        //│  │  │      IRepository.cs                  # 通用仓储接口
        //│  │  │      IUnitOfWork.cs                 # 工作单元接口
        //│  │  │      
        //│  │  └─Utilities                           # 工具类（如映射工具、缓存工具等）
        //│  │      
        //│  ├─WebApi                                # Web API 相关的应用服务
        //│  │  └─Trades
        //│  │      ├─Commands                         # CQRS 命令对象
        //│  │      │      # 例如：CreateMarketDataCommand.cs
        //│  │      ├─DTOs                             # 数据传输对象
        //│  │      │      CreateOrUpdateMarketDataDto.cs  # 创建或更新MarketData的DTO
        //│  │      │      MarketDataDto.cs                 # MarketData返回给前端的DTO
        //│  │      │      
        //│  │      ├─Handlers                         # CQRS 命令处理器
        //│  │      │      # 例如：CreateMarketDataHandler.cs
        //│  │      ├─IServices                        # 业务服务接口
        //│  │      │      IMarketDataService.cs          # MarketData相关的业务服务接口
        //│  │      │      
        //│  │      └─Services                         # 业务服务实现
        //│  │              MarketDataService.cs         # 实现IMarketDataService的业务服务
        //│  │                  
        //├─GalaxyNetCore.Domain                     # 领域层
        //│  │  GalaxyNetCore.Domain.csproj            # 领域层项目文件
        //│  │  
        //│  ├─Aggregates                             # 聚合根（DDD）
        //│  │      # 例如：OrderAggregate.cs
        //│  │  
        //│  ├─DomainServices                         # 领域服务
        //│  │      # 例如：MarketDataDomainService.cs
        //│  │  
        //│  ├─Entities                               # 领域实体
        //│  │      Log.cs                             # 日志实体
        //│  │      MarketDatum.cs                     # 市场数据实体
        //│  │      RiskManagementConfig.cs            # 风险管理配置实体
        //│  │      StrategyConfig.cs                  # 策略配置实体
        //│  │      TimeFrame.cs                       # 时间框架实体
        //│  │      TradeHistory.cs                    # 交易历史实体
        //│  │      TradingPair.cs                     # 交易对实体
        //│  │      
        //│  ├─ValueObjects                           # 值对象
        //│  │      # 例如：Money.cs, Address.cs
        //│  │      
        //│  ├─bin                                    # 编译输出文件夹（通常忽略）
        //│  └─obj                                    # 编译中间文件夹（通常忽略）
        //│                  
        //├─GalaxyNetCore.Infrastructure             # 基础设施层
        //│  │  GalaxyNetCore.Infrastructure.csproj   # 基础设施层项目文件
        //│  │  Remark.cs                             # 示例或占位文件
        //│  │  
        //│  ├─Common                                # 基础设施层共享资源
        //│  │  ├─Exceptions                           # 自定义异常类
        //│  │  │      # 例如：CustomException.cs, NotFoundException.cs
        //│  │  │      
        //│  │  ├─Middlewares                           # 基础设施中间件
        //│  │  │      # 例如：LoggingMiddleware.cs
        //│  │  │      
        //│  │  └─Utilities                             # 工具类
        //│  │          # 例如：Logger.cs, Mapper.cs
        //│  │      
        //│  ├─Data                                   # 数据访问
        //│  │      ApplicationDbContext.cs            # EF Core 数据上下文
        //│  │      
        //│  ├─ExternalServices                       # 外部服务接口与实现
        //│  │      # 例如：PaymentService.cs, NotificationService.cs
        //│  │      
        //│  ├─Migrations                             # EF Core 数据库迁移
        //│  │      # 自动生成的数据库迁移文件
        //│  │      
        //│  ├─Repositories                           # 仓储实现
        //│  │      Repository.cs                      # 通用仓储实现
        //│  │      UnitOfWork.cs                      # 工作单元实现
        //│  │      UserRepository.cs                  # 用户仓储实现（示例）
        //│  │      OrderRepository.cs                 # 订单仓储实现（示例）
        //│  │      
        //│  ├─obj                                    # 编译中间文件夹（通常忽略）
        //│  └─bin                                    # 编译输出文件夹（通常忽略）
        //│                  
        //└─Common                                   # 通用资源（可选）
        //    ├─Exceptions                             # 全局异常处理
        //    │      CustomException.cs                # 自定义异常类
        //    │      NotFoundException.cs               # 资源未找到异常
        //    │      
        //    ├─Middlewares                            # 全局中间件
        //    │      ExceptionHandlingMiddleware.cs    # 全局异常处理中间件
        //    │      
        //    └─Utilities                              # 公共工具类
        //            MapperProfile.cs                 # AutoMapper 映射配置
        //            Logger.cs                        # 日志工具类


        #endregion

        #region GalaxyNetCore.Domain
        //职责：

        //定义业务领域的核心概念和规则。
        //包含实体（Entities）、值对象（Value Objects）、聚合根（Aggregates）、领域服务（Domain Services）等。
        //主要内容：

        //Entities（实体）：
        //代表具有唯一标识的业务对象。
        //包含业务属性和行为。

        //Value Objects（值对象）：
        //表示无标识的对象，其价值完全由其属性决定。
        //具有不可变性

        //Aggregates（聚合） 和 Domain Services（领域服务）：
        //聚合用于定义业务规则的边界，确保数据的一致性。
        //领域服务用于实现跨实体的业务逻辑。
        #endregion

        #region GalaxyNetCore.Application
        //职责：

        //定义应用程序的用例和业务流程。
        //包含接口（Interfaces）、服务（Services）、DTOs（数据传输对象）、命令（Commands）、查询（Queries）等。
        //作为 Domain 层 和 Infrastructure 层 之间的桥梁，协调它们的交互。

        //主要内容：
        //Interfaces（接口）：
        //定义应用服务和仓储的契约。

        //DTOs（数据传输对象）：
        //用于在应用层与外部（如 API 层）之间传输数据，避免直接暴露领域实体。

        //Services（服务）：
        //实现业务逻辑，通常通过依赖注入调用仓储和领域服务。
        #endregion

        #region GalaxyNetCore.Infrastructure
        //实现 Application 层 定义的接口和契约。
        //处理具体的技术实现，如数据访问（使用 Entity Framework Core）、外部服务集成（如 Redis、消息队列等）。
        //包含仓储实现（Repositories）、数据库上下文（DbContext）、第三方库配置等。

        //Repositories（仓储实现）：
        //实现 Application 层 定义的仓储接口，负责具体的数据操作

        //Data（数据访问）：
        //包含 ApplicationDbContext 类，配置实体与数据库表的映射。

        //Configurations（配置）（可选）：
        //存放实体的配置类，使用 Fluent API 配置实体属性和关系。
        #endregion

        #region 生成DBcontent和模型类
        //Scaffold-DbContext "Server=DESKTOP-1761J6B\MSSQLSERVER2023;Database=AutoTradingSystem;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -ContextDir Data -Context ApplicationDbContext -Force
        #endregion

        #region 获取项目Tree
        //tree "C:\HeYi\.NET CORE\GALAXYNETCore" /F > "C:\HeYi\.NET CORE\GALAXYNETCore\project_tree.txt"
        #endregion
    }
}
