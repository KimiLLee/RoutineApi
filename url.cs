/*所有Guid请根据实际情况进行更改
GET
http://localhost:5000/api/companies
http://localhost:5000/api/companies/c71cea83-0e2a-4509-85f8-791279750fa4/employees
查找员工关键字变量q：http://localhost:5000/api/companies/0698b22f-806b-4eba-bca4-7d1b02beaeae/employees?q=Bim&gender=男
查找公司关键字变量searchTerm：http://localhost:5000/api/companies?searchTerm=A

POST
http://localhost:5000/api/companies
{
    "name":"CompanyD",
    "introduction":"qwerasdz zxcvzv"
}

http://localhost:5000/api/companies/c71cea83-0e2a-4509-85f8-791279750fa4/employees
{
	"employeeNo":"A000000001",
	"firstName":"Linus",
	"lastName":"Seb",
	"gender":1,
	"dateOfBirth":"1989-12-31"
}
//修改相应属性，可触发422错误以及自定义错误信息

{
    "name":"CompanyG",
    "introduction":"A Good Company",
    "employees":[
    	{
    		"employeeNo":"G000000001",
    		"firstName":"Kimi",
    		"lastName":"Lee",
    		"gender":1,
    		"dateOfBirth":"1998-11-20"
    	},
    	{
    		"employeeNo":"G000000002",
    		"firstName":"Kimimi",
    		"lastName":"LeeLee",
    		"gender":2,
    		"dateOfBirth":"1998-12-20"
    	}
    ]   
}
//公司员工集合的形式可以使用自定义attribute验证，但是无法完成资源创建，bug未解决


生成集合信息
http://localhost:5000/api/companycollections
[
    {
        "name":"CompnayE",
        "introduction":"66666,66666"
    },
    {
        "name":"CompnayF",
        "introduction":"2333323333"
    }
]

PATCH Content-Type:application/json-patch+json
整体更新：
1.修改Json消息，然后patch，返回204
2.修改employeeId，patch，则按照Json生成新employeeId的员工信息，返回201created

局部更新
http://localhost:5000/api/companies/c71cea83-0e2a-4509-85f8-791279750fa4/employees/404bd181-529f-464b-ae0b-29c187cadde8
[
	{
		"op":"replace",
		"path":"/employeeNo",
		"value":"A000000001"
	},
	{
		"op":"replace",
		"path":"/firstName",
		"value":"Lalala"
	},
	{
		"op":"remove",
		"path":"/dateOfBirth"
	},//移除现有值恢复为默认值
	{
		"op":"add",
		"path":"/dateOfBirth",
		"value":"2019-1-1"
	},
	{
		"op":"copy",
		"from":"/employeeNo",
		"path":"/lastName"
	},
	{
		"op":"remove",
		"path":"/employeeNo"
	},//验证用，移除不为空的属性值
	{
		"op":"remove",
		"path":"/werfsd"
	},//验证用，移除不存在的属性值，客户端错误返回4开头错误而非服务器端的5
]

新增
http://localhost:5000/api/companies/c71cea83-0e2a-4509-85f8-791279750fa4/employees/404bd181-529f-464b-ae0b-29c187cadd88
[
	{
		"op":"add",
		"path":"/employeeNo",
		"value":"A000000011"
	},
	{
		"op":"add",
		"path":"/firstName",
		"value":"ASD"
	},
	{
		"op":"add",
		"path":"/lastName",
		"value":"Zxc"
	},
	{
		"op":"add",
		"path":"/gender",
		"value":2
	},
	{
		"op":"add",
		"path":"/dateOfBirth",
		"value":"1950-1-25"
	}
]

DELETE
http://localhost:5000/api/companies/0698b22f-806b-4eba-bca4-7d1b02beaeae
http://localhost:5000/api/companies/c71cea83-0e2a-4509-85f8-791279750fa4/employees/5df6f722-e2a5-45e9-b1a7-0b634fe227e2
*/