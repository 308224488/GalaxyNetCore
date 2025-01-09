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

    }
}
