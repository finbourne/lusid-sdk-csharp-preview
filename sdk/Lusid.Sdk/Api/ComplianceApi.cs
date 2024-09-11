/*
 * LUSID API
 *
 * # Introduction  This page documents the [LUSID APIs](../../../api/swagger), which allows authorised clients to query and update their data within the LUSID platform.  SDKs to interact with the LUSID APIs are available in the following languages and frameworks:  * [C#](https://github.com/finbourne/lusid-sdk-csharp) * [Java](https://github.com/finbourne/lusid-sdk-java) * [JavaScript](https://github.com/finbourne/lusid-sdk-js) * [Python](https://github.com/finbourne/lusid-sdk-python) * [Angular](https://github.com/finbourne/lusid-sdk-angular)  The LUSID platform is made up of a number of sub-applications. You can find the API / swagger documentation by following the links in the table below.   | Application   | Description                                                                       | API / Swagger Documentation                          | |- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | LUSID         | Open, API-first, developer-friendly investment data platform.                     | [Swagger](../../../api/swagger/index.html)           | | Web app       | User-facing front end for LUSID.                                                  | [Swagger](../../../app/swagger/index.html)           | | Scheduler     | Automated job scheduler.                                                          | [Swagger](../../../scheduler2/swagger/index.html)    | | Insights      | Monitoring and troubleshooting service.                                           | [Swagger](../../../insights/swagger/index.html)      | | Identity      | Identity management for LUSID (in conjunction with Access)                        | [Swagger](../../../identity/swagger/index.html)      | | Access        | Access control for LUSID (in conjunction with Identity)                           | [Swagger](../../../access/swagger/index.html)        | | Drive         | Secure file repository and manager for collaboration.                             | [Swagger](../../../drive/swagger/index.html)         | | Luminesce     | Data virtualisation service (query data from multiple providers, including LUSID) | [Swagger](../../../honeycomb/swagger/index.html)     | | Notification  | Notification service.                                                             | [Swagger](../../../notification/swagger/index.html)  | | Configuration | File store for secrets and other sensitive information.                           | [Swagger](../../../configuration/swagger/index.html) | | Workflow      | Workflow service.                                                                 | [Swagger](../../../workflow/swagger/index.html)      |   # Error Codes  | Code|Name|Description | | - --|- --|- -- | | <a name=\"-10\">-10</a>|Server Configuration Error|  | | <a name=\"-1\">-1</a>|Unknown error|An unexpected error was encountered on our side. | | <a name=\"102\">102</a>|Version Not Found|  | | <a name=\"103\">103</a>|Api Rate Limit Violation|  | | <a name=\"104\">104</a>|Instrument Not Found|  | | <a name=\"105\">105</a>|Property Not Found|  | | <a name=\"106\">106</a>|Portfolio Recursion Depth|  | | <a name=\"108\">108</a>|Group Not Found|  | | <a name=\"109\">109</a>|Portfolio Not Found|  | | <a name=\"110\">110</a>|Property Schema Not Found|  | | <a name=\"111\">111</a>|Portfolio Ancestry Not Found|  | | <a name=\"112\">112</a>|Portfolio With Id Already Exists|  | | <a name=\"113\">113</a>|Orphaned Portfolio|  | | <a name=\"119\">119</a>|Missing Base Claims|  | | <a name=\"121\">121</a>|Property Not Defined|  | | <a name=\"122\">122</a>|Cannot Delete System Property|  | | <a name=\"123\">123</a>|Cannot Modify Immutable Property Field|  | | <a name=\"124\">124</a>|Property Already Exists|  | | <a name=\"125\">125</a>|Invalid Property Life Time|  | | <a name=\"126\">126</a>|Property Constraint Style Excludes Properties|  | | <a name=\"127\">127</a>|Cannot Modify Default Data Type|  | | <a name=\"128\">128</a>|Group Already Exists|  | | <a name=\"129\">129</a>|No Such Data Type|  | | <a name=\"130\">130</a>|Undefined Value For Data Type|  | | <a name=\"131\">131</a>|Unsupported Value Type Defined On Data Type|  | | <a name=\"132\">132</a>|Validation Error|  | | <a name=\"133\">133</a>|Loop Detected In Group Hierarchy|  | | <a name=\"134\">134</a>|Undefined Acceptable Values|  | | <a name=\"135\">135</a>|Sub Group Already Exists|  | | <a name=\"138\">138</a>|Price Source Not Found|  | | <a name=\"139\">139</a>|Analytic Store Not Found|  | | <a name=\"141\">141</a>|Analytic Store Already Exists|  | | <a name=\"143\">143</a>|Client Instrument Already Exists|  | | <a name=\"144\">144</a>|Duplicate In Parameter Set|  | | <a name=\"147\">147</a>|Results Not Found|  | | <a name=\"148\">148</a>|Order Field Not In Result Set|  | | <a name=\"149\">149</a>|Operation Failed|  | | <a name=\"150\">150</a>|Elastic Search Error|  | | <a name=\"151\">151</a>|Invalid Parameter Value|  | | <a name=\"153\">153</a>|Command Processing Failure|  | | <a name=\"154\">154</a>|Entity State Construction Failure|  | | <a name=\"155\">155</a>|Entity Timeline Does Not Exist|  | | <a name=\"156\">156</a>|Concurrency Conflict Failure|  | | <a name=\"157\">157</a>|Invalid Request|  | | <a name=\"158\">158</a>|Event Publish Unknown|  | | <a name=\"159\">159</a>|Event Query Failure|  | | <a name=\"160\">160</a>|Blob Did Not Exist|  | | <a name=\"162\">162</a>|Sub System Request Failure|  | | <a name=\"163\">163</a>|Sub System Configuration Failure|  | | <a name=\"165\">165</a>|Failed To Delete|  | | <a name=\"166\">166</a>|Upsert Client Instrument Failure|  | | <a name=\"167\">167</a>|Illegal As At Interval|  | | <a name=\"168\">168</a>|Illegal Bitemporal Query|  | | <a name=\"169\">169</a>|Invalid Alternate Id|  | | <a name=\"170\">170</a>|Cannot Add Non-Writable Properties To Entity|  | | <a name=\"171\">171</a>|Entity Already Exists In Group|  | | <a name=\"172\">172</a>|Entity With Id Does Not Exist|  | | <a name=\"173\">173</a>|Entity With Id Already Exists|  | | <a name=\"174\">174</a>|Derived Portfolio Details Do Not Exist|  | | <a name=\"175\">175</a>|Entity Not In Group|  | | <a name=\"176\">176</a>|Portfolio With Name Already Exists|  | | <a name=\"177\">177</a>|Invalid Transactions|  | | <a name=\"178\">178</a>|Reference Portfolio Not Found|  | | <a name=\"179\">179</a>|Duplicate Id|  | | <a name=\"180\">180</a>|Command Retrieval Failure|  | | <a name=\"181\">181</a>|Data Filter Application Failure|  | | <a name=\"182\">182</a>|Search Failed|  | | <a name=\"183\">183</a>|Movements Engine Configuration Key Failure|  | | <a name=\"184\">184</a>|Fx Rate Source Not Found|  | | <a name=\"185\">185</a>|Accrual Source Not Found|  | | <a name=\"186\">186</a>|Access Denied|  | | <a name=\"187\">187</a>|Invalid Identity Token|  | | <a name=\"188\">188</a>|Invalid Request Headers|  | | <a name=\"189\">189</a>|Price Not Found|  | | <a name=\"190\">190</a>|Invalid Sub Holding Keys Provided|  | | <a name=\"191\">191</a>|Duplicate Sub Holding Keys Provided|  | | <a name=\"192\">192</a>|Cut Definition Not Found|  | | <a name=\"193\">193</a>|Cut Definition Invalid|  | | <a name=\"194\">194</a>|Time Variant Property Deletion Date Unspecified|  | | <a name=\"195\">195</a>|Perpetual Property Deletion Date Specified|  | | <a name=\"196\">196</a>|Time Variant Property Upsert Date Unspecified|  | | <a name=\"197\">197</a>|Perpetual Property Upsert Date Specified|  | | <a name=\"200\">200</a>|Invalid Unit For Data Type|  | | <a name=\"201\">201</a>|Invalid Type For Data Type|  | | <a name=\"202\">202</a>|Invalid Value For Data Type|  | | <a name=\"203\">203</a>|Unit Not Defined For Data Type|  | | <a name=\"204\">204</a>|Units Not Supported On Data Type|  | | <a name=\"205\">205</a>|Cannot Specify Units On Data Type|  | | <a name=\"206\">206</a>|Unit Schema Inconsistent With Data Type|  | | <a name=\"207\">207</a>|Unit Definition Not Specified|  | | <a name=\"208\">208</a>|Duplicate Unit Definitions Specified|  | | <a name=\"209\">209</a>|Invalid Units Definition|  | | <a name=\"210\">210</a>|Invalid Instrument Identifier Unit|  | | <a name=\"211\">211</a>|Holdings Adjustment Does Not Exist|  | | <a name=\"212\">212</a>|Could Not Build Excel Url|  | | <a name=\"213\">213</a>|Could Not Get Excel Version|  | | <a name=\"214\">214</a>|Instrument By Code Not Found|  | | <a name=\"215\">215</a>|Entity Schema Does Not Exist|  | | <a name=\"216\">216</a>|Feature Not Supported On Portfolio Type|  | | <a name=\"217\">217</a>|Quote Not Found|  | | <a name=\"218\">218</a>|Invalid Quote Identifier|  | | <a name=\"219\">219</a>|Invalid Metric For Data Type|  | | <a name=\"220\">220</a>|Invalid Instrument Definition|  | | <a name=\"221\">221</a>|Instrument Upsert Failure|  | | <a name=\"222\">222</a>|Reference Portfolio Request Not Supported|  | | <a name=\"223\">223</a>|Transaction Portfolio Request Not Supported|  | | <a name=\"224\">224</a>|Invalid Property Value Assignment|  | | <a name=\"230\">230</a>|Transaction Type Not Found|  | | <a name=\"231\">231</a>|Transaction Type Duplication|  | | <a name=\"232\">232</a>|Portfolio Does Not Exist At Given Date|  | | <a name=\"233\">233</a>|Query Parser Failure|  | | <a name=\"234\">234</a>|Duplicate Constituent|  | | <a name=\"235\">235</a>|Unresolved Instrument Constituent|  | | <a name=\"236\">236</a>|Unresolved Instrument In Transition|  | | <a name=\"237\">237</a>|Missing Side Definitions|  | | <a name=\"240\">240</a>|Duplicate Calculations Failure|  | | <a name=\"299\">299</a>|Invalid Recipe|  | | <a name=\"300\">300</a>|Missing Recipe|  | | <a name=\"301\">301</a>|Dependencies|  | | <a name=\"304\">304</a>|Portfolio Preprocess Failure|  | | <a name=\"310\">310</a>|Valuation Engine Failure|  | | <a name=\"311\">311</a>|Task Factory Failure|  | | <a name=\"312\">312</a>|Task Evaluation Failure|  | | <a name=\"313\">313</a>|Task Generation Failure|  | | <a name=\"314\">314</a>|Engine Configuration Failure|  | | <a name=\"315\">315</a>|Model Specification Failure|  | | <a name=\"320\">320</a>|Market Data Key Failure|  | | <a name=\"321\">321</a>|Market Resolver Failure|  | | <a name=\"322\">322</a>|Market Data Failure|  | | <a name=\"330\">330</a>|Curve Failure|  | | <a name=\"331\">331</a>|Volatility Surface Failure|  | | <a name=\"332\">332</a>|Volatility Cube Failure|  | | <a name=\"350\">350</a>|Instrument Failure|  | | <a name=\"351\">351</a>|Cash Flows Failure|  | | <a name=\"352\">352</a>|Reference Data Failure|  | | <a name=\"360\">360</a>|Aggregation Failure|  | | <a name=\"361\">361</a>|Aggregation Measure Failure|  | | <a name=\"370\">370</a>|Result Retrieval Failure|  | | <a name=\"371\">371</a>|Result Processing Failure|  | | <a name=\"372\">372</a>|Vendor Result Processing Failure|  | | <a name=\"373\">373</a>|Vendor Result Mapping Failure|  | | <a name=\"374\">374</a>|Vendor Library Unauthorised|  | | <a name=\"375\">375</a>|Vendor Connectivity Error|  | | <a name=\"376\">376</a>|Vendor Interface Error|  | | <a name=\"377\">377</a>|Vendor Pricing Failure|  | | <a name=\"378\">378</a>|Vendor Translation Failure|  | | <a name=\"379\">379</a>|Vendor Key Mapping Failure|  | | <a name=\"380\">380</a>|Vendor Reflection Failure|  | | <a name=\"381\">381</a>|Vendor Process Failure|  | | <a name=\"382\">382</a>|Vendor System Failure|  | | <a name=\"390\">390</a>|Attempt To Upsert Duplicate Quotes|  | | <a name=\"391\">391</a>|Corporate Action Source Does Not Exist|  | | <a name=\"392\">392</a>|Corporate Action Source Already Exists|  | | <a name=\"393\">393</a>|Instrument Identifier Already In Use|  | | <a name=\"394\">394</a>|Properties Not Found|  | | <a name=\"395\">395</a>|Batch Operation Aborted|  | | <a name=\"400\">400</a>|Invalid Iso4217 Currency Code|  | | <a name=\"401\">401</a>|Cannot Assign Instrument Identifier To Currency|  | | <a name=\"402\">402</a>|Cannot Assign Currency Identifier To Non Currency|  | | <a name=\"403\">403</a>|Currency Instrument Cannot Be Deleted|  | | <a name=\"404\">404</a>|Currency Instrument Cannot Have Economic Definition|  | | <a name=\"405\">405</a>|Currency Instrument Cannot Have Lookthrough Portfolio|  | | <a name=\"406\">406</a>|Cannot Create Currency Instrument With Multiple Identifiers|  | | <a name=\"407\">407</a>|Specified Currency Is Undefined|  | | <a name=\"410\">410</a>|Index Does Not Exist|  | | <a name=\"411\">411</a>|Sort Field Does Not Exist|  | | <a name=\"413\">413</a>|Negative Pagination Parameters|  | | <a name=\"414\">414</a>|Invalid Search Syntax|  | | <a name=\"415\">415</a>|Filter Execution Timeout|  | | <a name=\"420\">420</a>|Side Definition Inconsistent|  | | <a name=\"450\">450</a>|Invalid Quote Access Metadata Rule|  | | <a name=\"451\">451</a>|Access Metadata Not Found|  | | <a name=\"452\">452</a>|Invalid Access Metadata Identifier|  | | <a name=\"460\">460</a>|Standard Resource Not Found|  | | <a name=\"461\">461</a>|Standard Resource Conflict|  | | <a name=\"462\">462</a>|Calendar Not Found|  | | <a name=\"463\">463</a>|Date In A Calendar Not Found|  | | <a name=\"464\">464</a>|Invalid Date Source Data|  | | <a name=\"465\">465</a>|Invalid Timezone|  | | <a name=\"601\">601</a>|Person Identifier Already In Use|  | | <a name=\"602\">602</a>|Person Not Found|  | | <a name=\"603\">603</a>|Cannot Set Identifier|  | | <a name=\"617\">617</a>|Invalid Recipe Specification In Request|  | | <a name=\"618\">618</a>|Inline Recipe Deserialisation Failure|  | | <a name=\"619\">619</a>|Identifier Types Not Set For Entity|  | | <a name=\"620\">620</a>|Cannot Delete All Client Defined Identifiers|  | | <a name=\"650\">650</a>|The Order requested was not found.|  | | <a name=\"654\">654</a>|The Allocation requested was not found.|  | | <a name=\"655\">655</a>|Cannot build the fx forward target with the given holdings.|  | | <a name=\"656\">656</a>|Group does not contain expected entities.|  | | <a name=\"665\">665</a>|Destination directory not found|  | | <a name=\"667\">667</a>|Relation definition already exists|  | | <a name=\"672\">672</a>|Could not retrieve file contents|  | | <a name=\"673\">673</a>|Missing entitlements for entities in Group|  | | <a name=\"674\">674</a>|Next Best Action not found|  | | <a name=\"676\">676</a>|Relation definition not defined|  | | <a name=\"677\">677</a>|Invalid entity identifier for relation|  | | <a name=\"681\">681</a>|Sorting by specified field not supported|One or more of the provided fields to order by were either invalid or not supported. | | <a name=\"682\">682</a>|Too many fields to sort by|The number of fields to sort the data by exceeds the number allowed by the endpoint | | <a name=\"684\">684</a>|Sequence Not Found|  | | <a name=\"685\">685</a>|Sequence Already Exists|  | | <a name=\"686\">686</a>|Non-cycling sequence has been exhausted|  | | <a name=\"687\">687</a>|Legal Entity Identifier Already In Use|  | | <a name=\"688\">688</a>|Legal Entity Not Found|  | | <a name=\"689\">689</a>|The supplied pagination token is invalid|  | | <a name=\"690\">690</a>|Property Type Is Not Supported|  | | <a name=\"691\">691</a>|Multiple Tax-lots For Currency Type Is Not Supported|  | | <a name=\"692\">692</a>|This endpoint does not support impersonation|  | | <a name=\"693\">693</a>|Entity type is not supported for Relationship|  | | <a name=\"694\">694</a>|Relationship Validation Failure|  | | <a name=\"695\">695</a>|Relationship Not Found|  | | <a name=\"697\">697</a>|Derived Property Formula No Longer Valid|  | | <a name=\"698\">698</a>|Story is not available|  | | <a name=\"703\">703</a>|Corporate Action Does Not Exist|  | | <a name=\"720\">720</a>|The provided sort and filter combination is not valid|  | | <a name=\"721\">721</a>|A2B generation failed|  | | <a name=\"722\">722</a>|Aggregated Return Calculation Failure|  | | <a name=\"723\">723</a>|Custom Entity Definition Identifier Already In Use|  | | <a name=\"724\">724</a>|Custom Entity Definition Not Found|  | | <a name=\"725\">725</a>|The Placement requested was not found.|  | | <a name=\"726\">726</a>|The Execution requested was not found.|  | | <a name=\"727\">727</a>|The Block requested was not found.|  | | <a name=\"728\">728</a>|The Participation requested was not found.|  | | <a name=\"729\">729</a>|The Package requested was not found.|  | | <a name=\"730\">730</a>|The OrderInstruction requested was not found.|  | | <a name=\"732\">732</a>|Custom Entity not found.|  | | <a name=\"733\">733</a>|Custom Entity Identifier already in use.|  | | <a name=\"735\">735</a>|Calculation Failed.|  | | <a name=\"736\">736</a>|An expected key on HttpResponse is missing.|  | | <a name=\"737\">737</a>|A required fee detail is missing.|  | | <a name=\"738\">738</a>|Zero rows were returned from Luminesce|  | | <a name=\"739\">739</a>|Provided Weekend Mask was invalid|  | | <a name=\"742\">742</a>|Custom Entity fields do not match the definition|  | | <a name=\"746\">746</a>|The provided sequence is not valid.|  | | <a name=\"751\">751</a>|The type of the Custom Entity is different than the type provided in the definition.|  | | <a name=\"752\">752</a>|Luminesce process returned an error.|  | | <a name=\"753\">753</a>|File name or content incompatible with operation.|  | | <a name=\"755\">755</a>|Schema of response from Drive is not as expected.|  | | <a name=\"757\">757</a>|Schema of response from Luminesce is not as expected.|  | | <a name=\"758\">758</a>|Luminesce timed out.|  | | <a name=\"763\">763</a>|Invalid Lusid Entity Identifier Unit|  | | <a name=\"768\">768</a>|Fee rule not found.|  | | <a name=\"769\">769</a>|Cannot update the base currency of a portfolio with transactions loaded|  | | <a name=\"771\">771</a>|Transaction configuration source not found|  | | <a name=\"774\">774</a>|Compliance rule not found.|  | | <a name=\"775\">775</a>|Fund accounting document cannot be processed.|  | | <a name=\"778\">778</a>|Unable to look up FX rate from trade ccy to portfolio ccy for some of the trades.|  | | <a name=\"782\">782</a>|The Property definition dataType is not matching the derivation formula dataType|  | | <a name=\"783\">783</a>|The Property definition domain is not supported for derived properties|  | | <a name=\"788\">788</a>|Compliance run not found failure.|  | | <a name=\"790\">790</a>|Custom Entity has missing or invalid identifiers|  | | <a name=\"791\">791</a>|Custom Entity definition already exists|  | | <a name=\"792\">792</a>|Compliance PropertyKey is missing.|  | | <a name=\"793\">793</a>|Compliance Criteria Value for matching is missing.|  | | <a name=\"795\">795</a>|Cannot delete identifier definition|  | | <a name=\"796\">796</a>|Tax rule set not found.|  | | <a name=\"797\">797</a>|A tax rule set with this id already exists.|  | | <a name=\"798\">798</a>|Multiple rule sets for the same property key are applicable.|  | | <a name=\"799\">799</a>|The request must contain a date or diary entry.|  | | <a name=\"800\">800</a>|Can not upsert an instrument event of this type.|  | | <a name=\"801\">801</a>|The instrument event does not exist.|  | | <a name=\"802\">802</a>|The Instrument event is missing salient information.|  | | <a name=\"803\">803</a>|The Instrument event could not be processed.|  | | <a name=\"804\">804</a>|Some data requested does not follow the order graph assumptions.|  | | <a name=\"805\">805</a>|The instrument event type does not exist.|  | | <a name=\"806\">806</a>|The transaction template specification does not exist.|  | | <a name=\"807\">807</a>|The default transaction template does not exist.|  | | <a name=\"808\">808</a>|The transaction template does not exist.|  | | <a name=\"811\">811</a>|A price could not be found for an order.|  | | <a name=\"812\">812</a>|A price could not be found for an allocation.|  | | <a name=\"813\">813</a>|Chart of Accounts not found.|  | | <a name=\"814\">814</a>|Account not found.|  | | <a name=\"815\">815</a>|Abor not found.|  | | <a name=\"816\">816</a>|Abor Configuration not found.|  | | <a name=\"817\">817</a>|Reconciliation mapping not found|  | | <a name=\"818\">818</a>|Attribute type could not be deleted because it doesn't exist.|  | | <a name=\"819\">819</a>|Reconciliation not found.|  | | <a name=\"820\">820</a>|Custodian Account not found.|  | | <a name=\"821\">821</a>|Allocation Failure|  | | <a name=\"822\">822</a>|Reconciliation run not found|  | | <a name=\"823\">823</a>|Reconciliation break not found|  | | <a name=\"824\">824</a>|Entity link type could not be deleted because it doesn't exist.|  | | <a name=\"828\">828</a>|Address key definition not found.|  | | <a name=\"829\">829</a>|Compliance template not found.|  | | <a name=\"830\">830</a>|Action not supported|  | | <a name=\"831\">831</a>|Reference list not found.|  | | <a name=\"832\">832</a>|Posting Module not found.|  | | <a name=\"833\">833</a>|The type of parameter provided did not match that required by the compliance rule.|  | | <a name=\"834\">834</a>|The parameters provided by a rule did not match those required by its template.|  | | <a name=\"835\">835</a>|The entity has a property in a domain that is not supprted for that entity type.|  | | <a name=\"836\">836</a>|Structured result data not found.|  | | <a name=\"837\">837</a>|Diary entry not found.|  | | <a name=\"838\">838</a>|Diary entry could not be created.|  | | <a name=\"839\">839</a>|Diary entry already exists.|  | | <a name=\"861\">861</a>|Compliance run summary not found.|  | | <a name=\"869\">869</a>|Conflicting instrument properties in batch.|  | | <a name=\"870\">870</a>|Compliance run summary already exists.|  | | <a name=\"871\">871</a>|The specified impersonated user does not exist|  | | <a name=\"874\">874</a>|Provided Property Domain is not supported for entity filter.|  | | <a name=\"875\">875</a>|Cannot Delete System Reference List.|  | | <a name=\"876\">876</a>|Cleardown Module not found.|  | | <a name=\"879\">879</a>|Portfolios do not have the same base currency|  | | <a name=\"880\">880</a>|There was a problem with the definition of the compliance expression.|  | | <a name=\"881\">881</a>|Block overplaced.|  | | <a name=\"882\">882</a>|Order not approved.|  | | <a name=\"883\">883</a>|Cannot update the shared fields of a block with associated orders.|  | | <a name=\"886\">886</a>|Cannot lock the period.|  | | <a name=\"887\">887</a>|Cannot apply clear down module.|  | | <a name=\"888\">888</a>|Cannot upsert Instrument Event Instruction.|  | | <a name=\"889\">889</a>|Cannot read Instrument Event Instruction.|  | | <a name=\"895\">895</a>|The Capital Ratio Calculation Is Wrong.|  | | <a name=\"910\">910</a>|Cannot update a block referenced by a placement.|  | | <a name=\"911\">911</a>|A Fund that references this Abor already exists.|  | | <a name=\"912\">912</a>|Cannot add decision to Staged Modification.|  | | <a name=\"913\">913</a>|The Staged Modification could not be applied.|  | | <a name=\"914\">914</a>|Action cannot be executed.|  | | <a name=\"915\">915</a>|Cannot upsert multiple versions of the same property in one request.|  | | <a name=\"916\">916</a>|Placement and direct descendents have more executed quantity than total placement quantity.|  | | <a name=\"917\">917</a>|Cannot update a placement with this EntryType.|  | | <a name=\"918\">918</a>|Cannot update a placement in this State.|  | | <a name=\"919\">919</a>|Placement could not be cancelled.|  | | <a name=\"920\">920</a>|Share Class not configured in Fund|  | | <a name=\"921\">921</a>|Share Class Sub Holding Key not configured in Portfolio|  | | <a name=\"922\">922</a>|Could not update an order.|  | | <a name=\"923\">923</a>|Multiple sets of Share Class Sub Holding Keys configured across the Portfolios of a Fund.|  | 
 *
 * The version of the OpenAPI document: 1.1.414
 * Contact: info@finbourne.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Lusid.Sdk.Client;
using Lusid.Sdk.Model;

namespace Lusid.Sdk.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IComplianceApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// [EARLY ACCESS] CreateComplianceTemplate: Create a Compliance Rule Template
        /// </summary>
        /// <remarks>
        /// Use this endpoint to create a compliance template.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="createComplianceTemplateRequest">Request to create a compliance rule template.</param>
        /// <returns>ComplianceRuleTemplate</returns>
        ComplianceRuleTemplate CreateComplianceTemplate(string scope, CreateComplianceTemplateRequest createComplianceTemplateRequest);

        /// <summary>
        /// [EARLY ACCESS] CreateComplianceTemplate: Create a Compliance Rule Template
        /// </summary>
        /// <remarks>
        /// Use this endpoint to create a compliance template.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="createComplianceTemplateRequest">Request to create a compliance rule template.</param>
        /// <returns>ApiResponse of ComplianceRuleTemplate</returns>
        ApiResponse<ComplianceRuleTemplate> CreateComplianceTemplateWithHttpInfo(string scope, CreateComplianceTemplateRequest createComplianceTemplateRequest);
        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceRule: Delete compliance rule.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to delete a compliance rule. The rule will be recoverable for asat times earlier than the  delete time, but will otherwise appear to have never existed.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <returns>DeletedEntityResponse</returns>
        DeletedEntityResponse DeleteComplianceRule(string scope, string code);

        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceRule: Delete compliance rule.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to delete a compliance rule. The rule will be recoverable for asat times earlier than the  delete time, but will otherwise appear to have never existed.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        ApiResponse<DeletedEntityResponse> DeleteComplianceRuleWithHttpInfo(string scope, string code);
        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceTemplate: Delete a ComplianceRuleTemplate
        /// </summary>
        /// <remarks>
        /// Delete the compliance rule template uniquely defined by the scope and code.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the template to be deleted.</param>
        /// <param name="code">The code of the template to be deleted.</param>
        /// <returns>DeletedEntityResponse</returns>
        DeletedEntityResponse DeleteComplianceTemplate(string scope, string code);

        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceTemplate: Delete a ComplianceRuleTemplate
        /// </summary>
        /// <remarks>
        /// Delete the compliance rule template uniquely defined by the scope and code.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the template to be deleted.</param>
        /// <param name="code">The code of the template to be deleted.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        ApiResponse<DeletedEntityResponse> DeleteComplianceTemplateWithHttpInfo(string scope, string code);
        /// <summary>
        /// [EARLY ACCESS] GetComplianceRule: Get compliance rule.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to retrieve a single compliance rule.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <param name="asAt">Optional. Asat time for query. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto the rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. (optional)</param>
        /// <returns>ComplianceRuleResponse</returns>
        ComplianceRuleResponse GetComplianceRule(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>));

        /// <summary>
        /// [EARLY ACCESS] GetComplianceRule: Get compliance rule.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to retrieve a single compliance rule.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <param name="asAt">Optional. Asat time for query. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto the rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. (optional)</param>
        /// <returns>ApiResponse of ComplianceRuleResponse</returns>
        ApiResponse<ComplianceRuleResponse> GetComplianceRuleWithHttpInfo(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>));
        /// <summary>
        /// [EARLY ACCESS] GetComplianceRuleResult: Get detailed results for a specific rule within a compliance run.
        /// </summary>
        /// <remarks>
        /// Specify a run scope and code from a previously run compliance check, and the scope and code of a rule within that run, to get detailed results for that rule.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Run Scope.</param>
        /// <param name="runCode">Required: Run Code.</param>
        /// <param name="ruleScope">Required: Rule Scope.</param>
        /// <param name="ruleCode">Required: Rule Code.</param>
        /// <returns>ComplianceRuleResultV2</returns>
        ComplianceRuleResultV2 GetComplianceRuleResult(string runScope, string runCode, string ruleScope, string ruleCode);

        /// <summary>
        /// [EARLY ACCESS] GetComplianceRuleResult: Get detailed results for a specific rule within a compliance run.
        /// </summary>
        /// <remarks>
        /// Specify a run scope and code from a previously run compliance check, and the scope and code of a rule within that run, to get detailed results for that rule.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Run Scope.</param>
        /// <param name="runCode">Required: Run Code.</param>
        /// <param name="ruleScope">Required: Rule Scope.</param>
        /// <param name="ruleCode">Required: Rule Code.</param>
        /// <returns>ApiResponse of ComplianceRuleResultV2</returns>
        ApiResponse<ComplianceRuleResultV2> GetComplianceRuleResultWithHttpInfo(string runScope, string runCode, string ruleScope, string ruleCode);
        /// <summary>
        /// [EARLY ACCESS] GetComplianceTemplate: Get the requested compliance template.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch a specific compliance template.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Scope of TemplateID</param>
        /// <param name="code">Code of TemplateID</param>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <returns>ComplianceTemplate</returns>
        ComplianceTemplate GetComplianceTemplate(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?));

        /// <summary>
        /// [EARLY ACCESS] GetComplianceTemplate: Get the requested compliance template.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch a specific compliance template.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Scope of TemplateID</param>
        /// <param name="code">Code of TemplateID</param>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <returns>ApiResponse of ComplianceTemplate</returns>
        ApiResponse<ComplianceTemplate> GetComplianceTemplateWithHttpInfo(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?));
        /// <summary>
        /// [EARLY ACCESS] GetDecoratedComplianceRunSummary: Get decorated summary results for a specific compliance run.
        /// </summary>
        /// <remarks>
        /// Specify a run scope and code from a previously run compliance check to get an overview of result details.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Required: Run Scope.</param>
        /// <param name="code">Required: Run Code.</param>
        /// <returns>DecoratedComplianceRunSummary</returns>
        DecoratedComplianceRunSummary GetDecoratedComplianceRunSummary(string scope, string code);

        /// <summary>
        /// [EARLY ACCESS] GetDecoratedComplianceRunSummary: Get decorated summary results for a specific compliance run.
        /// </summary>
        /// <remarks>
        /// Specify a run scope and code from a previously run compliance check to get an overview of result details.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Required: Run Scope.</param>
        /// <param name="code">Required: Run Code.</param>
        /// <returns>ApiResponse of DecoratedComplianceRunSummary</returns>
        ApiResponse<DecoratedComplianceRunSummary> GetDecoratedComplianceRunSummaryWithHttpInfo(string scope, string code);
        /// <summary>
        /// [EARLY ACCESS] ListComplianceRules: List compliance rules.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to retrieve all compliance rules, or a subset defined by an optional filter.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. Asat time. (optional)</param>
        /// <param name="page">Optional. Pagination token. (optional)</param>
        /// <param name="limit">Optional. Entries per page. (optional)</param>
        /// <param name="filter">Optional. Filter. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto each rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. If not provided will return all the entitled properties for each rule. (optional)</param>
        /// <returns>PagedResourceListOfComplianceRuleResponse</returns>
        PagedResourceListOfComplianceRuleResponse ListComplianceRules(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>));

        /// <summary>
        /// [EARLY ACCESS] ListComplianceRules: List compliance rules.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to retrieve all compliance rules, or a subset defined by an optional filter.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. Asat time. (optional)</param>
        /// <param name="page">Optional. Pagination token. (optional)</param>
        /// <param name="limit">Optional. Entries per page. (optional)</param>
        /// <param name="filter">Optional. Filter. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto each rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. If not provided will return all the entitled properties for each rule. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfComplianceRuleResponse</returns>
        ApiResponse<PagedResourceListOfComplianceRuleResponse> ListComplianceRulesWithHttpInfo(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>));
        /// <summary>
        /// [EARLY ACCESS] ListComplianceRuns: List historical compliance run identifiers.
        /// </summary>
        /// <remarks>
        /// Lists RunIds of prior compliance runs, or a subset with a filter.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="sortBy">Optional. A list of field names to sort by, each suffixed by \&quot;ASC\&quot; or \&quot;DESC\&quot; (optional)</param>
        /// <returns>PagedResourceListOfComplianceRunInfoV2</returns>
        PagedResourceListOfComplianceRunInfoV2 ListComplianceRuns(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>));

        /// <summary>
        /// [EARLY ACCESS] ListComplianceRuns: List historical compliance run identifiers.
        /// </summary>
        /// <remarks>
        /// Lists RunIds of prior compliance runs, or a subset with a filter.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="sortBy">Optional. A list of field names to sort by, each suffixed by \&quot;ASC\&quot; or \&quot;DESC\&quot; (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfComplianceRunInfoV2</returns>
        ApiResponse<PagedResourceListOfComplianceRunInfoV2> ListComplianceRunsWithHttpInfo(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>));
        /// <summary>
        /// [EARLY ACCESS] ListComplianceTemplates: List compliance templates.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch a list of all available compliance template ids, or a subset using a filter.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <returns>PagedResourceListOfComplianceTemplate</returns>
        PagedResourceListOfComplianceTemplate ListComplianceTemplates(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string));

        /// <summary>
        /// [EARLY ACCESS] ListComplianceTemplates: List compliance templates.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch a list of all available compliance template ids, or a subset using a filter.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfComplianceTemplate</returns>
        ApiResponse<PagedResourceListOfComplianceTemplate> ListComplianceTemplatesWithHttpInfo(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string));
        /// <summary>
        /// [EARLY ACCESS] RunCompliance: Run a compliance check.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to run a compliance check using rules from a specific scope.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <returns>ComplianceRunInfoV2</returns>
        ComplianceRunInfoV2 RunCompliance(string runScope, string ruleScope, bool isPreTrade, string recipeIdScope, string recipeIdCode);

        /// <summary>
        /// [EARLY ACCESS] RunCompliance: Run a compliance check.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to run a compliance check using rules from a specific scope.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <returns>ApiResponse of ComplianceRunInfoV2</returns>
        ApiResponse<ComplianceRunInfoV2> RunComplianceWithHttpInfo(string runScope, string ruleScope, bool isPreTrade, string recipeIdScope, string recipeIdCode);
        /// <summary>
        /// [EARLY ACCESS] RunCompliancePreview: Run a compliance check.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to run a compliance check using rules from a specific scope.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <param name="complianceRunConfiguration">Configuration options for the compliance run. (optional)</param>
        /// <returns>ComplianceRunInfoV2</returns>
        ComplianceRunInfoV2 RunCompliancePreview(string runScope, string ruleScope, string recipeIdScope, string recipeIdCode, ComplianceRunConfiguration complianceRunConfiguration = default(ComplianceRunConfiguration));

        /// <summary>
        /// [EARLY ACCESS] RunCompliancePreview: Run a compliance check.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to run a compliance check using rules from a specific scope.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <param name="complianceRunConfiguration">Configuration options for the compliance run. (optional)</param>
        /// <returns>ApiResponse of ComplianceRunInfoV2</returns>
        ApiResponse<ComplianceRunInfoV2> RunCompliancePreviewWithHttpInfo(string runScope, string ruleScope, string recipeIdScope, string recipeIdCode, ComplianceRunConfiguration complianceRunConfiguration = default(ComplianceRunConfiguration));
        /// <summary>
        /// [EARLY ACCESS] UpdateComplianceTemplate: Update a ComplianceRuleTemplate
        /// </summary>
        /// <remarks>
        /// Use this endpoint to update a specified compliance template.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="code">The code of the Compliance Rule Template.</param>
        /// <param name="updateComplianceTemplateRequest">Request to update a compliance rule template.</param>
        /// <returns>ComplianceRuleTemplate</returns>
        ComplianceRuleTemplate UpdateComplianceTemplate(string scope, string code, UpdateComplianceTemplateRequest updateComplianceTemplateRequest);

        /// <summary>
        /// [EARLY ACCESS] UpdateComplianceTemplate: Update a ComplianceRuleTemplate
        /// </summary>
        /// <remarks>
        /// Use this endpoint to update a specified compliance template.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="code">The code of the Compliance Rule Template.</param>
        /// <param name="updateComplianceTemplateRequest">Request to update a compliance rule template.</param>
        /// <returns>ApiResponse of ComplianceRuleTemplate</returns>
        ApiResponse<ComplianceRuleTemplate> UpdateComplianceTemplateWithHttpInfo(string scope, string code, UpdateComplianceTemplateRequest updateComplianceTemplateRequest);
        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRule: Upsert a compliance rule.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to upsert a single compliance rule. The template and variation specified must already  exist, as must the portfolio group. The parameters passed must match those required by the template variation.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRuleRequest"> (optional)</param>
        /// <returns>ComplianceRuleResponse</returns>
        ComplianceRuleResponse UpsertComplianceRule(UpsertComplianceRuleRequest upsertComplianceRuleRequest = default(UpsertComplianceRuleRequest));

        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRule: Upsert a compliance rule.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to upsert a single compliance rule. The template and variation specified must already  exist, as must the portfolio group. The parameters passed must match those required by the template variation.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRuleRequest"> (optional)</param>
        /// <returns>ApiResponse of ComplianceRuleResponse</returns>
        ApiResponse<ComplianceRuleResponse> UpsertComplianceRuleWithHttpInfo(UpsertComplianceRuleRequest upsertComplianceRuleRequest = default(UpsertComplianceRuleRequest));
        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRunSummary: Upsert a compliance run summary.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to upsert a compliance run result summary.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRunSummaryRequest"> (optional)</param>
        /// <returns>UpsertComplianceRunSummaryResult</returns>
        UpsertComplianceRunSummaryResult UpsertComplianceRunSummary(UpsertComplianceRunSummaryRequest upsertComplianceRunSummaryRequest = default(UpsertComplianceRunSummaryRequest));

        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRunSummary: Upsert a compliance run summary.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to upsert a compliance run result summary.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRunSummaryRequest"> (optional)</param>
        /// <returns>ApiResponse of UpsertComplianceRunSummaryResult</returns>
        ApiResponse<UpsertComplianceRunSummaryResult> UpsertComplianceRunSummaryWithHttpInfo(UpsertComplianceRunSummaryRequest upsertComplianceRunSummaryRequest = default(UpsertComplianceRunSummaryRequest));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IComplianceApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// [EARLY ACCESS] CreateComplianceTemplate: Create a Compliance Rule Template
        /// </summary>
        /// <remarks>
        /// Use this endpoint to create a compliance template.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="createComplianceTemplateRequest">Request to create a compliance rule template.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRuleTemplate</returns>
        System.Threading.Tasks.Task<ComplianceRuleTemplate> CreateComplianceTemplateAsync(string scope, CreateComplianceTemplateRequest createComplianceTemplateRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] CreateComplianceTemplate: Create a Compliance Rule Template
        /// </summary>
        /// <remarks>
        /// Use this endpoint to create a compliance template.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="createComplianceTemplateRequest">Request to create a compliance rule template.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRuleTemplate)</returns>
        System.Threading.Tasks.Task<ApiResponse<ComplianceRuleTemplate>> CreateComplianceTemplateWithHttpInfoAsync(string scope, CreateComplianceTemplateRequest createComplianceTemplateRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceRule: Delete compliance rule.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to delete a compliance rule. The rule will be recoverable for asat times earlier than the  delete time, but will otherwise appear to have never existed.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        System.Threading.Tasks.Task<DeletedEntityResponse> DeleteComplianceRuleAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceRule: Delete compliance rule.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to delete a compliance rule. The rule will be recoverable for asat times earlier than the  delete time, but will otherwise appear to have never existed.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeletedEntityResponse>> DeleteComplianceRuleWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceTemplate: Delete a ComplianceRuleTemplate
        /// </summary>
        /// <remarks>
        /// Delete the compliance rule template uniquely defined by the scope and code.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the template to be deleted.</param>
        /// <param name="code">The code of the template to be deleted.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        System.Threading.Tasks.Task<DeletedEntityResponse> DeleteComplianceTemplateAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceTemplate: Delete a ComplianceRuleTemplate
        /// </summary>
        /// <remarks>
        /// Delete the compliance rule template uniquely defined by the scope and code.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the template to be deleted.</param>
        /// <param name="code">The code of the template to be deleted.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeletedEntityResponse>> DeleteComplianceTemplateWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] GetComplianceRule: Get compliance rule.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to retrieve a single compliance rule.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <param name="asAt">Optional. Asat time for query. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto the rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRuleResponse</returns>
        System.Threading.Tasks.Task<ComplianceRuleResponse> GetComplianceRuleAsync(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] GetComplianceRule: Get compliance rule.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to retrieve a single compliance rule.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <param name="asAt">Optional. Asat time for query. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto the rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRuleResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ComplianceRuleResponse>> GetComplianceRuleWithHttpInfoAsync(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] GetComplianceRuleResult: Get detailed results for a specific rule within a compliance run.
        /// </summary>
        /// <remarks>
        /// Specify a run scope and code from a previously run compliance check, and the scope and code of a rule within that run, to get detailed results for that rule.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Run Scope.</param>
        /// <param name="runCode">Required: Run Code.</param>
        /// <param name="ruleScope">Required: Rule Scope.</param>
        /// <param name="ruleCode">Required: Rule Code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRuleResultV2</returns>
        System.Threading.Tasks.Task<ComplianceRuleResultV2> GetComplianceRuleResultAsync(string runScope, string runCode, string ruleScope, string ruleCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] GetComplianceRuleResult: Get detailed results for a specific rule within a compliance run.
        /// </summary>
        /// <remarks>
        /// Specify a run scope and code from a previously run compliance check, and the scope and code of a rule within that run, to get detailed results for that rule.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Run Scope.</param>
        /// <param name="runCode">Required: Run Code.</param>
        /// <param name="ruleScope">Required: Rule Scope.</param>
        /// <param name="ruleCode">Required: Rule Code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRuleResultV2)</returns>
        System.Threading.Tasks.Task<ApiResponse<ComplianceRuleResultV2>> GetComplianceRuleResultWithHttpInfoAsync(string runScope, string runCode, string ruleScope, string ruleCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] GetComplianceTemplate: Get the requested compliance template.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch a specific compliance template.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Scope of TemplateID</param>
        /// <param name="code">Code of TemplateID</param>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceTemplate</returns>
        System.Threading.Tasks.Task<ComplianceTemplate> GetComplianceTemplateAsync(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] GetComplianceTemplate: Get the requested compliance template.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch a specific compliance template.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Scope of TemplateID</param>
        /// <param name="code">Code of TemplateID</param>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceTemplate)</returns>
        System.Threading.Tasks.Task<ApiResponse<ComplianceTemplate>> GetComplianceTemplateWithHttpInfoAsync(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] GetDecoratedComplianceRunSummary: Get decorated summary results for a specific compliance run.
        /// </summary>
        /// <remarks>
        /// Specify a run scope and code from a previously run compliance check to get an overview of result details.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Required: Run Scope.</param>
        /// <param name="code">Required: Run Code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DecoratedComplianceRunSummary</returns>
        System.Threading.Tasks.Task<DecoratedComplianceRunSummary> GetDecoratedComplianceRunSummaryAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] GetDecoratedComplianceRunSummary: Get decorated summary results for a specific compliance run.
        /// </summary>
        /// <remarks>
        /// Specify a run scope and code from a previously run compliance check to get an overview of result details.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Required: Run Scope.</param>
        /// <param name="code">Required: Run Code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DecoratedComplianceRunSummary)</returns>
        System.Threading.Tasks.Task<ApiResponse<DecoratedComplianceRunSummary>> GetDecoratedComplianceRunSummaryWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] ListComplianceRules: List compliance rules.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to retrieve all compliance rules, or a subset defined by an optional filter.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. Asat time. (optional)</param>
        /// <param name="page">Optional. Pagination token. (optional)</param>
        /// <param name="limit">Optional. Entries per page. (optional)</param>
        /// <param name="filter">Optional. Filter. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto each rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. If not provided will return all the entitled properties for each rule. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfComplianceRuleResponse</returns>
        System.Threading.Tasks.Task<PagedResourceListOfComplianceRuleResponse> ListComplianceRulesAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] ListComplianceRules: List compliance rules.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to retrieve all compliance rules, or a subset defined by an optional filter.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. Asat time. (optional)</param>
        /// <param name="page">Optional. Pagination token. (optional)</param>
        /// <param name="limit">Optional. Entries per page. (optional)</param>
        /// <param name="filter">Optional. Filter. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto each rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. If not provided will return all the entitled properties for each rule. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfComplianceRuleResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<PagedResourceListOfComplianceRuleResponse>> ListComplianceRulesWithHttpInfoAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] ListComplianceRuns: List historical compliance run identifiers.
        /// </summary>
        /// <remarks>
        /// Lists RunIds of prior compliance runs, or a subset with a filter.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="sortBy">Optional. A list of field names to sort by, each suffixed by \&quot;ASC\&quot; or \&quot;DESC\&quot; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfComplianceRunInfoV2</returns>
        System.Threading.Tasks.Task<PagedResourceListOfComplianceRunInfoV2> ListComplianceRunsAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] ListComplianceRuns: List historical compliance run identifiers.
        /// </summary>
        /// <remarks>
        /// Lists RunIds of prior compliance runs, or a subset with a filter.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="sortBy">Optional. A list of field names to sort by, each suffixed by \&quot;ASC\&quot; or \&quot;DESC\&quot; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfComplianceRunInfoV2)</returns>
        System.Threading.Tasks.Task<ApiResponse<PagedResourceListOfComplianceRunInfoV2>> ListComplianceRunsWithHttpInfoAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] ListComplianceTemplates: List compliance templates.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch a list of all available compliance template ids, or a subset using a filter.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfComplianceTemplate</returns>
        System.Threading.Tasks.Task<PagedResourceListOfComplianceTemplate> ListComplianceTemplatesAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] ListComplianceTemplates: List compliance templates.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to fetch a list of all available compliance template ids, or a subset using a filter.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfComplianceTemplate)</returns>
        System.Threading.Tasks.Task<ApiResponse<PagedResourceListOfComplianceTemplate>> ListComplianceTemplatesWithHttpInfoAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] RunCompliance: Run a compliance check.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to run a compliance check using rules from a specific scope.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRunInfoV2</returns>
        System.Threading.Tasks.Task<ComplianceRunInfoV2> RunComplianceAsync(string runScope, string ruleScope, bool isPreTrade, string recipeIdScope, string recipeIdCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] RunCompliance: Run a compliance check.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to run a compliance check using rules from a specific scope.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRunInfoV2)</returns>
        System.Threading.Tasks.Task<ApiResponse<ComplianceRunInfoV2>> RunComplianceWithHttpInfoAsync(string runScope, string ruleScope, bool isPreTrade, string recipeIdScope, string recipeIdCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] RunCompliancePreview: Run a compliance check.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to run a compliance check using rules from a specific scope.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <param name="complianceRunConfiguration">Configuration options for the compliance run. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRunInfoV2</returns>
        System.Threading.Tasks.Task<ComplianceRunInfoV2> RunCompliancePreviewAsync(string runScope, string ruleScope, string recipeIdScope, string recipeIdCode, ComplianceRunConfiguration complianceRunConfiguration = default(ComplianceRunConfiguration), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] RunCompliancePreview: Run a compliance check.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to run a compliance check using rules from a specific scope.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <param name="complianceRunConfiguration">Configuration options for the compliance run. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRunInfoV2)</returns>
        System.Threading.Tasks.Task<ApiResponse<ComplianceRunInfoV2>> RunCompliancePreviewWithHttpInfoAsync(string runScope, string ruleScope, string recipeIdScope, string recipeIdCode, ComplianceRunConfiguration complianceRunConfiguration = default(ComplianceRunConfiguration), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] UpdateComplianceTemplate: Update a ComplianceRuleTemplate
        /// </summary>
        /// <remarks>
        /// Use this endpoint to update a specified compliance template.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="code">The code of the Compliance Rule Template.</param>
        /// <param name="updateComplianceTemplateRequest">Request to update a compliance rule template.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRuleTemplate</returns>
        System.Threading.Tasks.Task<ComplianceRuleTemplate> UpdateComplianceTemplateAsync(string scope, string code, UpdateComplianceTemplateRequest updateComplianceTemplateRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] UpdateComplianceTemplate: Update a ComplianceRuleTemplate
        /// </summary>
        /// <remarks>
        /// Use this endpoint to update a specified compliance template.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="code">The code of the Compliance Rule Template.</param>
        /// <param name="updateComplianceTemplateRequest">Request to update a compliance rule template.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRuleTemplate)</returns>
        System.Threading.Tasks.Task<ApiResponse<ComplianceRuleTemplate>> UpdateComplianceTemplateWithHttpInfoAsync(string scope, string code, UpdateComplianceTemplateRequest updateComplianceTemplateRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRule: Upsert a compliance rule.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to upsert a single compliance rule. The template and variation specified must already  exist, as must the portfolio group. The parameters passed must match those required by the template variation.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRuleRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRuleResponse</returns>
        System.Threading.Tasks.Task<ComplianceRuleResponse> UpsertComplianceRuleAsync(UpsertComplianceRuleRequest upsertComplianceRuleRequest = default(UpsertComplianceRuleRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRule: Upsert a compliance rule.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to upsert a single compliance rule. The template and variation specified must already  exist, as must the portfolio group. The parameters passed must match those required by the template variation.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRuleRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRuleResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ComplianceRuleResponse>> UpsertComplianceRuleWithHttpInfoAsync(UpsertComplianceRuleRequest upsertComplianceRuleRequest = default(UpsertComplianceRuleRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRunSummary: Upsert a compliance run summary.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to upsert a compliance run result summary.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRunSummaryRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UpsertComplianceRunSummaryResult</returns>
        System.Threading.Tasks.Task<UpsertComplianceRunSummaryResult> UpsertComplianceRunSummaryAsync(UpsertComplianceRunSummaryRequest upsertComplianceRunSummaryRequest = default(UpsertComplianceRunSummaryRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRunSummary: Upsert a compliance run summary.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to upsert a compliance run result summary.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRunSummaryRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UpsertComplianceRunSummaryResult)</returns>
        System.Threading.Tasks.Task<ApiResponse<UpsertComplianceRunSummaryResult>> UpsertComplianceRunSummaryWithHttpInfoAsync(UpsertComplianceRunSummaryRequest upsertComplianceRunSummaryRequest = default(UpsertComplianceRunSummaryRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IComplianceApi : IComplianceApiSync, IComplianceApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ComplianceApi : IComplianceApi
    {
        private Lusid.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplianceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ComplianceApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplianceApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ComplianceApi(String basePath)
        {
            this.Configuration = Lusid.Sdk.Client.Configuration.MergeConfigurations(
                Lusid.Sdk.Client.GlobalConfiguration.Instance,
                new Lusid.Sdk.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Lusid.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplianceApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ComplianceApi(Lusid.Sdk.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = configuration;
            this.Client = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Lusid.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplianceApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ComplianceApi(Lusid.Sdk.Client.ISynchronousClient client, Lusid.Sdk.Client.IAsynchronousClient asyncClient, Lusid.Sdk.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Lusid.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Lusid.Sdk.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Lusid.Sdk.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Lusid.Sdk.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Lusid.Sdk.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// [EARLY ACCESS] CreateComplianceTemplate: Create a Compliance Rule Template Use this endpoint to create a compliance template.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="createComplianceTemplateRequest">Request to create a compliance rule template.</param>
        /// <returns>ComplianceRuleTemplate</returns>
        public ComplianceRuleTemplate CreateComplianceTemplate(string scope, CreateComplianceTemplateRequest createComplianceTemplateRequest)
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRuleTemplate> localVarResponse = CreateComplianceTemplateWithHttpInfo(scope, createComplianceTemplateRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] CreateComplianceTemplate: Create a Compliance Rule Template Use this endpoint to create a compliance template.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="createComplianceTemplateRequest">Request to create a compliance rule template.</param>
        /// <returns>ApiResponse of ComplianceRuleTemplate</returns>
        public Lusid.Sdk.Client.ApiResponse<ComplianceRuleTemplate> CreateComplianceTemplateWithHttpInfo(string scope, CreateComplianceTemplateRequest createComplianceTemplateRequest)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->CreateComplianceTemplate");

            // verify the required parameter 'createComplianceTemplateRequest' is set
            if (createComplianceTemplateRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'createComplianceTemplateRequest' when calling ComplianceApi->CreateComplianceTemplate");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.Data = createComplianceTemplateRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ComplianceRuleTemplate>("/api/compliance/templates/{scope}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateComplianceTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] CreateComplianceTemplate: Create a Compliance Rule Template Use this endpoint to create a compliance template.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="createComplianceTemplateRequest">Request to create a compliance rule template.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRuleTemplate</returns>
        public async System.Threading.Tasks.Task<ComplianceRuleTemplate> CreateComplianceTemplateAsync(string scope, CreateComplianceTemplateRequest createComplianceTemplateRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRuleTemplate> localVarResponse = await CreateComplianceTemplateWithHttpInfoAsync(scope, createComplianceTemplateRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] CreateComplianceTemplate: Create a Compliance Rule Template Use this endpoint to create a compliance template.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="createComplianceTemplateRequest">Request to create a compliance rule template.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRuleTemplate)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ComplianceRuleTemplate>> CreateComplianceTemplateWithHttpInfoAsync(string scope, CreateComplianceTemplateRequest createComplianceTemplateRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->CreateComplianceTemplate");

            // verify the required parameter 'createComplianceTemplateRequest' is set
            if (createComplianceTemplateRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'createComplianceTemplateRequest' when calling ComplianceApi->CreateComplianceTemplate");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.Data = createComplianceTemplateRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ComplianceRuleTemplate>("/api/compliance/templates/{scope}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateComplianceTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceRule: Delete compliance rule. Use this endpoint to delete a compliance rule. The rule will be recoverable for asat times earlier than the  delete time, but will otherwise appear to have never existed.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <returns>DeletedEntityResponse</returns>
        public DeletedEntityResponse DeleteComplianceRule(string scope, string code)
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = DeleteComplianceRuleWithHttpInfo(scope, code);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceRule: Delete compliance rule. Use this endpoint to delete a compliance rule. The rule will be recoverable for asat times earlier than the  delete time, but will otherwise appear to have never existed.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> DeleteComplianceRuleWithHttpInfo(string scope, string code)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->DeleteComplianceRule");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ComplianceApi->DeleteComplianceRule");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Delete<DeletedEntityResponse>("/api/compliance/rules/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteComplianceRule", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceRule: Delete compliance rule. Use this endpoint to delete a compliance rule. The rule will be recoverable for asat times earlier than the  delete time, but will otherwise appear to have never existed.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        public async System.Threading.Tasks.Task<DeletedEntityResponse> DeleteComplianceRuleAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = await DeleteComplianceRuleWithHttpInfoAsync(scope, code, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceRule: Delete compliance rule. Use this endpoint to delete a compliance rule. The rule will be recoverable for asat times earlier than the  delete time, but will otherwise appear to have never existed.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse>> DeleteComplianceRuleWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->DeleteComplianceRule");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ComplianceApi->DeleteComplianceRule");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<DeletedEntityResponse>("/api/compliance/rules/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteComplianceRule", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceTemplate: Delete a ComplianceRuleTemplate Delete the compliance rule template uniquely defined by the scope and code.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the template to be deleted.</param>
        /// <param name="code">The code of the template to be deleted.</param>
        /// <returns>DeletedEntityResponse</returns>
        public DeletedEntityResponse DeleteComplianceTemplate(string scope, string code)
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = DeleteComplianceTemplateWithHttpInfo(scope, code);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceTemplate: Delete a ComplianceRuleTemplate Delete the compliance rule template uniquely defined by the scope and code.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the template to be deleted.</param>
        /// <param name="code">The code of the template to be deleted.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> DeleteComplianceTemplateWithHttpInfo(string scope, string code)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->DeleteComplianceTemplate");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ComplianceApi->DeleteComplianceTemplate");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Delete<DeletedEntityResponse>("/api/compliance/templates/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteComplianceTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceTemplate: Delete a ComplianceRuleTemplate Delete the compliance rule template uniquely defined by the scope and code.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the template to be deleted.</param>
        /// <param name="code">The code of the template to be deleted.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        public async System.Threading.Tasks.Task<DeletedEntityResponse> DeleteComplianceTemplateAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = await DeleteComplianceTemplateWithHttpInfoAsync(scope, code, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] DeleteComplianceTemplate: Delete a ComplianceRuleTemplate Delete the compliance rule template uniquely defined by the scope and code.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the template to be deleted.</param>
        /// <param name="code">The code of the template to be deleted.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse>> DeleteComplianceTemplateWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->DeleteComplianceTemplate");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ComplianceApi->DeleteComplianceTemplate");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<DeletedEntityResponse>("/api/compliance/templates/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteComplianceTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] GetComplianceRule: Get compliance rule. Use this endpoint to retrieve a single compliance rule.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <param name="asAt">Optional. Asat time for query. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto the rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. (optional)</param>
        /// <returns>ComplianceRuleResponse</returns>
        public ComplianceRuleResponse GetComplianceRule(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRuleResponse> localVarResponse = GetComplianceRuleWithHttpInfo(scope, code, asAt, propertyKeys);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] GetComplianceRule: Get compliance rule. Use this endpoint to retrieve a single compliance rule.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <param name="asAt">Optional. Asat time for query. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto the rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. (optional)</param>
        /// <returns>ApiResponse of ComplianceRuleResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<ComplianceRuleResponse> GetComplianceRuleWithHttpInfo(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->GetComplianceRule");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ComplianceApi->GetComplianceRule");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (propertyKeys != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "propertyKeys", propertyKeys));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Get<ComplianceRuleResponse>("/api/compliance/rules/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetComplianceRule", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] GetComplianceRule: Get compliance rule. Use this endpoint to retrieve a single compliance rule.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <param name="asAt">Optional. Asat time for query. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto the rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRuleResponse</returns>
        public async System.Threading.Tasks.Task<ComplianceRuleResponse> GetComplianceRuleAsync(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRuleResponse> localVarResponse = await GetComplianceRuleWithHttpInfoAsync(scope, code, asAt, propertyKeys, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] GetComplianceRule: Get compliance rule. Use this endpoint to retrieve a single compliance rule.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The compliance rule&#39;s scope.</param>
        /// <param name="code">The compliance rule&#39;s code.</param>
        /// <param name="asAt">Optional. Asat time for query. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto the rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRuleResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ComplianceRuleResponse>> GetComplianceRuleWithHttpInfoAsync(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->GetComplianceRule");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ComplianceApi->GetComplianceRule");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (propertyKeys != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "propertyKeys", propertyKeys));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ComplianceRuleResponse>("/api/compliance/rules/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetComplianceRule", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] GetComplianceRuleResult: Get detailed results for a specific rule within a compliance run. Specify a run scope and code from a previously run compliance check, and the scope and code of a rule within that run, to get detailed results for that rule.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Run Scope.</param>
        /// <param name="runCode">Required: Run Code.</param>
        /// <param name="ruleScope">Required: Rule Scope.</param>
        /// <param name="ruleCode">Required: Rule Code.</param>
        /// <returns>ComplianceRuleResultV2</returns>
        public ComplianceRuleResultV2 GetComplianceRuleResult(string runScope, string runCode, string ruleScope, string ruleCode)
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRuleResultV2> localVarResponse = GetComplianceRuleResultWithHttpInfo(runScope, runCode, ruleScope, ruleCode);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] GetComplianceRuleResult: Get detailed results for a specific rule within a compliance run. Specify a run scope and code from a previously run compliance check, and the scope and code of a rule within that run, to get detailed results for that rule.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Run Scope.</param>
        /// <param name="runCode">Required: Run Code.</param>
        /// <param name="ruleScope">Required: Rule Scope.</param>
        /// <param name="ruleCode">Required: Rule Code.</param>
        /// <returns>ApiResponse of ComplianceRuleResultV2</returns>
        public Lusid.Sdk.Client.ApiResponse<ComplianceRuleResultV2> GetComplianceRuleResultWithHttpInfo(string runScope, string runCode, string ruleScope, string ruleCode)
        {
            // verify the required parameter 'runScope' is set
            if (runScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'runScope' when calling ComplianceApi->GetComplianceRuleResult");

            // verify the required parameter 'runCode' is set
            if (runCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'runCode' when calling ComplianceApi->GetComplianceRuleResult");

            // verify the required parameter 'ruleScope' is set
            if (ruleScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'ruleScope' when calling ComplianceApi->GetComplianceRuleResult");

            // verify the required parameter 'ruleCode' is set
            if (ruleCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'ruleCode' when calling ComplianceApi->GetComplianceRuleResult");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runScope", Lusid.Sdk.Client.ClientUtils.ParameterToString(runScope)); // path parameter
            localVarRequestOptions.PathParameters.Add("runCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(runCode)); // path parameter
            localVarRequestOptions.PathParameters.Add("ruleScope", Lusid.Sdk.Client.ClientUtils.ParameterToString(ruleScope)); // path parameter
            localVarRequestOptions.PathParameters.Add("ruleCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(ruleCode)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Get<ComplianceRuleResultV2>("/api/compliance/runs/summary/{runScope}/{runCode}/{ruleScope}/{ruleCode}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetComplianceRuleResult", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] GetComplianceRuleResult: Get detailed results for a specific rule within a compliance run. Specify a run scope and code from a previously run compliance check, and the scope and code of a rule within that run, to get detailed results for that rule.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Run Scope.</param>
        /// <param name="runCode">Required: Run Code.</param>
        /// <param name="ruleScope">Required: Rule Scope.</param>
        /// <param name="ruleCode">Required: Rule Code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRuleResultV2</returns>
        public async System.Threading.Tasks.Task<ComplianceRuleResultV2> GetComplianceRuleResultAsync(string runScope, string runCode, string ruleScope, string ruleCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRuleResultV2> localVarResponse = await GetComplianceRuleResultWithHttpInfoAsync(runScope, runCode, ruleScope, ruleCode, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] GetComplianceRuleResult: Get detailed results for a specific rule within a compliance run. Specify a run scope and code from a previously run compliance check, and the scope and code of a rule within that run, to get detailed results for that rule.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Run Scope.</param>
        /// <param name="runCode">Required: Run Code.</param>
        /// <param name="ruleScope">Required: Rule Scope.</param>
        /// <param name="ruleCode">Required: Rule Code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRuleResultV2)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ComplianceRuleResultV2>> GetComplianceRuleResultWithHttpInfoAsync(string runScope, string runCode, string ruleScope, string ruleCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'runScope' is set
            if (runScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'runScope' when calling ComplianceApi->GetComplianceRuleResult");

            // verify the required parameter 'runCode' is set
            if (runCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'runCode' when calling ComplianceApi->GetComplianceRuleResult");

            // verify the required parameter 'ruleScope' is set
            if (ruleScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'ruleScope' when calling ComplianceApi->GetComplianceRuleResult");

            // verify the required parameter 'ruleCode' is set
            if (ruleCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'ruleCode' when calling ComplianceApi->GetComplianceRuleResult");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("runScope", Lusid.Sdk.Client.ClientUtils.ParameterToString(runScope)); // path parameter
            localVarRequestOptions.PathParameters.Add("runCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(runCode)); // path parameter
            localVarRequestOptions.PathParameters.Add("ruleScope", Lusid.Sdk.Client.ClientUtils.ParameterToString(ruleScope)); // path parameter
            localVarRequestOptions.PathParameters.Add("ruleCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(ruleCode)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ComplianceRuleResultV2>("/api/compliance/runs/summary/{runScope}/{runCode}/{ruleScope}/{ruleCode}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetComplianceRuleResult", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] GetComplianceTemplate: Get the requested compliance template. Use this endpoint to fetch a specific compliance template.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Scope of TemplateID</param>
        /// <param name="code">Code of TemplateID</param>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <returns>ComplianceTemplate</returns>
        public ComplianceTemplate GetComplianceTemplate(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceTemplate> localVarResponse = GetComplianceTemplateWithHttpInfo(scope, code, asAt);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] GetComplianceTemplate: Get the requested compliance template. Use this endpoint to fetch a specific compliance template.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Scope of TemplateID</param>
        /// <param name="code">Code of TemplateID</param>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <returns>ApiResponse of ComplianceTemplate</returns>
        public Lusid.Sdk.Client.ApiResponse<ComplianceTemplate> GetComplianceTemplateWithHttpInfo(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->GetComplianceTemplate");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ComplianceApi->GetComplianceTemplate");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Get<ComplianceTemplate>("/api/compliance/templates/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetComplianceTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] GetComplianceTemplate: Get the requested compliance template. Use this endpoint to fetch a specific compliance template.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Scope of TemplateID</param>
        /// <param name="code">Code of TemplateID</param>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceTemplate</returns>
        public async System.Threading.Tasks.Task<ComplianceTemplate> GetComplianceTemplateAsync(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceTemplate> localVarResponse = await GetComplianceTemplateWithHttpInfoAsync(scope, code, asAt, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] GetComplianceTemplate: Get the requested compliance template. Use this endpoint to fetch a specific compliance template.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Scope of TemplateID</param>
        /// <param name="code">Code of TemplateID</param>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceTemplate)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ComplianceTemplate>> GetComplianceTemplateWithHttpInfoAsync(string scope, string code, DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->GetComplianceTemplate");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ComplianceApi->GetComplianceTemplate");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ComplianceTemplate>("/api/compliance/templates/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetComplianceTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] GetDecoratedComplianceRunSummary: Get decorated summary results for a specific compliance run. Specify a run scope and code from a previously run compliance check to get an overview of result details.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Required: Run Scope.</param>
        /// <param name="code">Required: Run Code.</param>
        /// <returns>DecoratedComplianceRunSummary</returns>
        public DecoratedComplianceRunSummary GetDecoratedComplianceRunSummary(string scope, string code)
        {
            Lusid.Sdk.Client.ApiResponse<DecoratedComplianceRunSummary> localVarResponse = GetDecoratedComplianceRunSummaryWithHttpInfo(scope, code);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] GetDecoratedComplianceRunSummary: Get decorated summary results for a specific compliance run. Specify a run scope and code from a previously run compliance check to get an overview of result details.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Required: Run Scope.</param>
        /// <param name="code">Required: Run Code.</param>
        /// <returns>ApiResponse of DecoratedComplianceRunSummary</returns>
        public Lusid.Sdk.Client.ApiResponse<DecoratedComplianceRunSummary> GetDecoratedComplianceRunSummaryWithHttpInfo(string scope, string code)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->GetDecoratedComplianceRunSummary");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ComplianceApi->GetDecoratedComplianceRunSummary");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Get<DecoratedComplianceRunSummary>("/api/compliance/runs/summary/{scope}/{code}/$decorate", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetDecoratedComplianceRunSummary", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] GetDecoratedComplianceRunSummary: Get decorated summary results for a specific compliance run. Specify a run scope and code from a previously run compliance check to get an overview of result details.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Required: Run Scope.</param>
        /// <param name="code">Required: Run Code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DecoratedComplianceRunSummary</returns>
        public async System.Threading.Tasks.Task<DecoratedComplianceRunSummary> GetDecoratedComplianceRunSummaryAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DecoratedComplianceRunSummary> localVarResponse = await GetDecoratedComplianceRunSummaryWithHttpInfoAsync(scope, code, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] GetDecoratedComplianceRunSummary: Get decorated summary results for a specific compliance run. Specify a run scope and code from a previously run compliance check to get an overview of result details.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">Required: Run Scope.</param>
        /// <param name="code">Required: Run Code.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DecoratedComplianceRunSummary)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DecoratedComplianceRunSummary>> GetDecoratedComplianceRunSummaryWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->GetDecoratedComplianceRunSummary");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ComplianceApi->GetDecoratedComplianceRunSummary");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<DecoratedComplianceRunSummary>("/api/compliance/runs/summary/{scope}/{code}/$decorate", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetDecoratedComplianceRunSummary", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] ListComplianceRules: List compliance rules. Use this endpoint to retrieve all compliance rules, or a subset defined by an optional filter.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. Asat time. (optional)</param>
        /// <param name="page">Optional. Pagination token. (optional)</param>
        /// <param name="limit">Optional. Entries per page. (optional)</param>
        /// <param name="filter">Optional. Filter. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto each rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. If not provided will return all the entitled properties for each rule. (optional)</param>
        /// <returns>PagedResourceListOfComplianceRuleResponse</returns>
        public PagedResourceListOfComplianceRuleResponse ListComplianceRules(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfComplianceRuleResponse> localVarResponse = ListComplianceRulesWithHttpInfo(asAt, page, limit, filter, propertyKeys);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] ListComplianceRules: List compliance rules. Use this endpoint to retrieve all compliance rules, or a subset defined by an optional filter.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. Asat time. (optional)</param>
        /// <param name="page">Optional. Pagination token. (optional)</param>
        /// <param name="limit">Optional. Entries per page. (optional)</param>
        /// <param name="filter">Optional. Filter. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto each rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. If not provided will return all the entitled properties for each rule. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfComplianceRuleResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<PagedResourceListOfComplianceRuleResponse> ListComplianceRulesWithHttpInfo(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (propertyKeys != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "propertyKeys", propertyKeys));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Get<PagedResourceListOfComplianceRuleResponse>("/api/compliance/rules", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListComplianceRules", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] ListComplianceRules: List compliance rules. Use this endpoint to retrieve all compliance rules, or a subset defined by an optional filter.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. Asat time. (optional)</param>
        /// <param name="page">Optional. Pagination token. (optional)</param>
        /// <param name="limit">Optional. Entries per page. (optional)</param>
        /// <param name="filter">Optional. Filter. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto each rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. If not provided will return all the entitled properties for each rule. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfComplianceRuleResponse</returns>
        public async System.Threading.Tasks.Task<PagedResourceListOfComplianceRuleResponse> ListComplianceRulesAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfComplianceRuleResponse> localVarResponse = await ListComplianceRulesWithHttpInfoAsync(asAt, page, limit, filter, propertyKeys, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] ListComplianceRules: List compliance rules. Use this endpoint to retrieve all compliance rules, or a subset defined by an optional filter.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. Asat time. (optional)</param>
        /// <param name="page">Optional. Pagination token. (optional)</param>
        /// <param name="limit">Optional. Entries per page. (optional)</param>
        /// <param name="filter">Optional. Filter. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Compliance&#39; domain to decorate onto each rule.              These must take the format {domain}/{scope}/{code}, for example &#39;Compliance/live/UCITS&#39;. If not provided will return all the entitled properties for each rule. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfComplianceRuleResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<PagedResourceListOfComplianceRuleResponse>> ListComplianceRulesWithHttpInfoAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (propertyKeys != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "propertyKeys", propertyKeys));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<PagedResourceListOfComplianceRuleResponse>("/api/compliance/rules", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListComplianceRules", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] ListComplianceRuns: List historical compliance run identifiers. Lists RunIds of prior compliance runs, or a subset with a filter.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="sortBy">Optional. A list of field names to sort by, each suffixed by \&quot;ASC\&quot; or \&quot;DESC\&quot; (optional)</param>
        /// <returns>PagedResourceListOfComplianceRunInfoV2</returns>
        public PagedResourceListOfComplianceRunInfoV2 ListComplianceRuns(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfComplianceRunInfoV2> localVarResponse = ListComplianceRunsWithHttpInfo(asAt, page, limit, filter, sortBy);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] ListComplianceRuns: List historical compliance run identifiers. Lists RunIds of prior compliance runs, or a subset with a filter.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="sortBy">Optional. A list of field names to sort by, each suffixed by \&quot;ASC\&quot; or \&quot;DESC\&quot; (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfComplianceRunInfoV2</returns>
        public Lusid.Sdk.Client.ApiResponse<PagedResourceListOfComplianceRunInfoV2> ListComplianceRunsWithHttpInfo(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (sortBy != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "sortBy", sortBy));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Get<PagedResourceListOfComplianceRunInfoV2>("/api/compliance/runs", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListComplianceRuns", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] ListComplianceRuns: List historical compliance run identifiers. Lists RunIds of prior compliance runs, or a subset with a filter.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="sortBy">Optional. A list of field names to sort by, each suffixed by \&quot;ASC\&quot; or \&quot;DESC\&quot; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfComplianceRunInfoV2</returns>
        public async System.Threading.Tasks.Task<PagedResourceListOfComplianceRunInfoV2> ListComplianceRunsAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfComplianceRunInfoV2> localVarResponse = await ListComplianceRunsWithHttpInfoAsync(asAt, page, limit, filter, sortBy, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] ListComplianceRuns: List historical compliance run identifiers. Lists RunIds of prior compliance runs, or a subset with a filter.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="sortBy">Optional. A list of field names to sort by, each suffixed by \&quot;ASC\&quot; or \&quot;DESC\&quot; (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfComplianceRunInfoV2)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<PagedResourceListOfComplianceRunInfoV2>> ListComplianceRunsWithHttpInfoAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (sortBy != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "sortBy", sortBy));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<PagedResourceListOfComplianceRunInfoV2>("/api/compliance/runs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListComplianceRuns", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] ListComplianceTemplates: List compliance templates. Use this endpoint to fetch a list of all available compliance template ids, or a subset using a filter.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <returns>PagedResourceListOfComplianceTemplate</returns>
        public PagedResourceListOfComplianceTemplate ListComplianceTemplates(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfComplianceTemplate> localVarResponse = ListComplianceTemplatesWithHttpInfo(asAt, page, limit, filter);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] ListComplianceTemplates: List compliance templates. Use this endpoint to fetch a list of all available compliance template ids, or a subset using a filter.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfComplianceTemplate</returns>
        public Lusid.Sdk.Client.ApiResponse<PagedResourceListOfComplianceTemplate> ListComplianceTemplatesWithHttpInfo(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Get<PagedResourceListOfComplianceTemplate>("/api/compliance/templates", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListComplianceTemplates", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] ListComplianceTemplates: List compliance templates. Use this endpoint to fetch a list of all available compliance template ids, or a subset using a filter.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfComplianceTemplate</returns>
        public async System.Threading.Tasks.Task<PagedResourceListOfComplianceTemplate> ListComplianceTemplatesAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfComplianceTemplate> localVarResponse = await ListComplianceTemplatesWithHttpInfoAsync(asAt, page, limit, filter, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] ListComplianceTemplates: List compliance templates. Use this endpoint to fetch a list of all available compliance template ids, or a subset using a filter.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="asAt">Optional. The time at which to get results from. Default : latest (optional)</param>
        /// <param name="page">Optional. The pagination token to use to continue listing compliance runs from a previous call to list compliance runs.              This value is returned from the previous call. If a pagination token is provided the sortBy, filter, and asAt fields              must not have changed since the original request. (optional)</param>
        /// <param name="limit">Optional. When paginating, limit the number of returned results to this many. (optional)</param>
        /// <param name="filter">Optional. Expression to filter the result set. Read more about filtering results from LUSID here https://support.lusid.com/filtering-results-from-lusid. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfComplianceTemplate)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<PagedResourceListOfComplianceTemplate>> ListComplianceTemplatesWithHttpInfoAsync(DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<PagedResourceListOfComplianceTemplate>("/api/compliance/templates", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListComplianceTemplates", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] RunCompliance: Run a compliance check. Use this endpoint to run a compliance check using rules from a specific scope.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <returns>ComplianceRunInfoV2</returns>
        public ComplianceRunInfoV2 RunCompliance(string runScope, string ruleScope, bool isPreTrade, string recipeIdScope, string recipeIdCode)
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRunInfoV2> localVarResponse = RunComplianceWithHttpInfo(runScope, ruleScope, isPreTrade, recipeIdScope, recipeIdCode);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] RunCompliance: Run a compliance check. Use this endpoint to run a compliance check using rules from a specific scope.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <returns>ApiResponse of ComplianceRunInfoV2</returns>
        public Lusid.Sdk.Client.ApiResponse<ComplianceRunInfoV2> RunComplianceWithHttpInfo(string runScope, string ruleScope, bool isPreTrade, string recipeIdScope, string recipeIdCode)
        {
            // verify the required parameter 'runScope' is set
            if (runScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'runScope' when calling ComplianceApi->RunCompliance");

            // verify the required parameter 'ruleScope' is set
            if (ruleScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'ruleScope' when calling ComplianceApi->RunCompliance");

            // verify the required parameter 'recipeIdScope' is set
            if (recipeIdScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'recipeIdScope' when calling ComplianceApi->RunCompliance");

            // verify the required parameter 'recipeIdCode' is set
            if (recipeIdCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'recipeIdCode' when calling ComplianceApi->RunCompliance");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "runScope", runScope));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "ruleScope", ruleScope));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "isPreTrade", isPreTrade));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "recipeIdScope", recipeIdScope));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "recipeIdCode", recipeIdCode));

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ComplianceRunInfoV2>("/api/compliance/runs", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RunCompliance", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] RunCompliance: Run a compliance check. Use this endpoint to run a compliance check using rules from a specific scope.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRunInfoV2</returns>
        public async System.Threading.Tasks.Task<ComplianceRunInfoV2> RunComplianceAsync(string runScope, string ruleScope, bool isPreTrade, string recipeIdScope, string recipeIdCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRunInfoV2> localVarResponse = await RunComplianceWithHttpInfoAsync(runScope, ruleScope, isPreTrade, recipeIdScope, recipeIdCode, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] RunCompliance: Run a compliance check. Use this endpoint to run a compliance check using rules from a specific scope.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="isPreTrade">Required: Boolean flag indicating if a run should be PreTrade (Including orders). For post-trade only, set to false</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRunInfoV2)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ComplianceRunInfoV2>> RunComplianceWithHttpInfoAsync(string runScope, string ruleScope, bool isPreTrade, string recipeIdScope, string recipeIdCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'runScope' is set
            if (runScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'runScope' when calling ComplianceApi->RunCompliance");

            // verify the required parameter 'ruleScope' is set
            if (ruleScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'ruleScope' when calling ComplianceApi->RunCompliance");

            // verify the required parameter 'recipeIdScope' is set
            if (recipeIdScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'recipeIdScope' when calling ComplianceApi->RunCompliance");

            // verify the required parameter 'recipeIdCode' is set
            if (recipeIdCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'recipeIdCode' when calling ComplianceApi->RunCompliance");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "runScope", runScope));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "ruleScope", ruleScope));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "isPreTrade", isPreTrade));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "recipeIdScope", recipeIdScope));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "recipeIdCode", recipeIdCode));

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ComplianceRunInfoV2>("/api/compliance/runs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RunCompliance", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] RunCompliancePreview: Run a compliance check. Use this endpoint to run a compliance check using rules from a specific scope.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <param name="complianceRunConfiguration">Configuration options for the compliance run. (optional)</param>
        /// <returns>ComplianceRunInfoV2</returns>
        public ComplianceRunInfoV2 RunCompliancePreview(string runScope, string ruleScope, string recipeIdScope, string recipeIdCode, ComplianceRunConfiguration complianceRunConfiguration = default(ComplianceRunConfiguration))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRunInfoV2> localVarResponse = RunCompliancePreviewWithHttpInfo(runScope, ruleScope, recipeIdScope, recipeIdCode, complianceRunConfiguration);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] RunCompliancePreview: Run a compliance check. Use this endpoint to run a compliance check using rules from a specific scope.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <param name="complianceRunConfiguration">Configuration options for the compliance run. (optional)</param>
        /// <returns>ApiResponse of ComplianceRunInfoV2</returns>
        public Lusid.Sdk.Client.ApiResponse<ComplianceRunInfoV2> RunCompliancePreviewWithHttpInfo(string runScope, string ruleScope, string recipeIdScope, string recipeIdCode, ComplianceRunConfiguration complianceRunConfiguration = default(ComplianceRunConfiguration))
        {
            // verify the required parameter 'runScope' is set
            if (runScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'runScope' when calling ComplianceApi->RunCompliancePreview");

            // verify the required parameter 'ruleScope' is set
            if (ruleScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'ruleScope' when calling ComplianceApi->RunCompliancePreview");

            // verify the required parameter 'recipeIdScope' is set
            if (recipeIdScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'recipeIdScope' when calling ComplianceApi->RunCompliancePreview");

            // verify the required parameter 'recipeIdCode' is set
            if (recipeIdCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'recipeIdCode' when calling ComplianceApi->RunCompliancePreview");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "runScope", runScope));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "ruleScope", ruleScope));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "recipeIdScope", recipeIdScope));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "recipeIdCode", recipeIdCode));
            localVarRequestOptions.Data = complianceRunConfiguration;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ComplianceRunInfoV2>("/api/compliance/preview/runs", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RunCompliancePreview", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] RunCompliancePreview: Run a compliance check. Use this endpoint to run a compliance check using rules from a specific scope.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <param name="complianceRunConfiguration">Configuration options for the compliance run. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRunInfoV2</returns>
        public async System.Threading.Tasks.Task<ComplianceRunInfoV2> RunCompliancePreviewAsync(string runScope, string ruleScope, string recipeIdScope, string recipeIdCode, ComplianceRunConfiguration complianceRunConfiguration = default(ComplianceRunConfiguration), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRunInfoV2> localVarResponse = await RunCompliancePreviewWithHttpInfoAsync(runScope, ruleScope, recipeIdScope, recipeIdCode, complianceRunConfiguration, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] RunCompliancePreview: Run a compliance check. Use this endpoint to run a compliance check using rules from a specific scope.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="runScope">Required: Scope to save the run results in.</param>
        /// <param name="ruleScope">Required: Scope from which to select rules to be run.</param>
        /// <param name="recipeIdScope">Required: the scope of the recipe to be used</param>
        /// <param name="recipeIdCode">Required: The code of the recipe to be used. If left blank, the default recipe will be used.</param>
        /// <param name="complianceRunConfiguration">Configuration options for the compliance run. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRunInfoV2)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ComplianceRunInfoV2>> RunCompliancePreviewWithHttpInfoAsync(string runScope, string ruleScope, string recipeIdScope, string recipeIdCode, ComplianceRunConfiguration complianceRunConfiguration = default(ComplianceRunConfiguration), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'runScope' is set
            if (runScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'runScope' when calling ComplianceApi->RunCompliancePreview");

            // verify the required parameter 'ruleScope' is set
            if (ruleScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'ruleScope' when calling ComplianceApi->RunCompliancePreview");

            // verify the required parameter 'recipeIdScope' is set
            if (recipeIdScope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'recipeIdScope' when calling ComplianceApi->RunCompliancePreview");

            // verify the required parameter 'recipeIdCode' is set
            if (recipeIdCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'recipeIdCode' when calling ComplianceApi->RunCompliancePreview");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "runScope", runScope));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "ruleScope", ruleScope));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "recipeIdScope", recipeIdScope));
            localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "recipeIdCode", recipeIdCode));
            localVarRequestOptions.Data = complianceRunConfiguration;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ComplianceRunInfoV2>("/api/compliance/preview/runs", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("RunCompliancePreview", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] UpdateComplianceTemplate: Update a ComplianceRuleTemplate Use this endpoint to update a specified compliance template.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="code">The code of the Compliance Rule Template.</param>
        /// <param name="updateComplianceTemplateRequest">Request to update a compliance rule template.</param>
        /// <returns>ComplianceRuleTemplate</returns>
        public ComplianceRuleTemplate UpdateComplianceTemplate(string scope, string code, UpdateComplianceTemplateRequest updateComplianceTemplateRequest)
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRuleTemplate> localVarResponse = UpdateComplianceTemplateWithHttpInfo(scope, code, updateComplianceTemplateRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] UpdateComplianceTemplate: Update a ComplianceRuleTemplate Use this endpoint to update a specified compliance template.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="code">The code of the Compliance Rule Template.</param>
        /// <param name="updateComplianceTemplateRequest">Request to update a compliance rule template.</param>
        /// <returns>ApiResponse of ComplianceRuleTemplate</returns>
        public Lusid.Sdk.Client.ApiResponse<ComplianceRuleTemplate> UpdateComplianceTemplateWithHttpInfo(string scope, string code, UpdateComplianceTemplateRequest updateComplianceTemplateRequest)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->UpdateComplianceTemplate");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ComplianceApi->UpdateComplianceTemplate");

            // verify the required parameter 'updateComplianceTemplateRequest' is set
            if (updateComplianceTemplateRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'updateComplianceTemplateRequest' when calling ComplianceApi->UpdateComplianceTemplate");

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.Data = updateComplianceTemplateRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Put<ComplianceRuleTemplate>("/api/compliance/templates/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateComplianceTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] UpdateComplianceTemplate: Update a ComplianceRuleTemplate Use this endpoint to update a specified compliance template.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="code">The code of the Compliance Rule Template.</param>
        /// <param name="updateComplianceTemplateRequest">Request to update a compliance rule template.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRuleTemplate</returns>
        public async System.Threading.Tasks.Task<ComplianceRuleTemplate> UpdateComplianceTemplateAsync(string scope, string code, UpdateComplianceTemplateRequest updateComplianceTemplateRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRuleTemplate> localVarResponse = await UpdateComplianceTemplateWithHttpInfoAsync(scope, code, updateComplianceTemplateRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] UpdateComplianceTemplate: Update a ComplianceRuleTemplate Use this endpoint to update a specified compliance template.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Compliance Rule Template.</param>
        /// <param name="code">The code of the Compliance Rule Template.</param>
        /// <param name="updateComplianceTemplateRequest">Request to update a compliance rule template.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRuleTemplate)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ComplianceRuleTemplate>> UpdateComplianceTemplateWithHttpInfoAsync(string scope, string code, UpdateComplianceTemplateRequest updateComplianceTemplateRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling ComplianceApi->UpdateComplianceTemplate");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling ComplianceApi->UpdateComplianceTemplate");

            // verify the required parameter 'updateComplianceTemplateRequest' is set
            if (updateComplianceTemplateRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'updateComplianceTemplateRequest' when calling ComplianceApi->UpdateComplianceTemplate");


            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.PathParameters.Add("scope", Lusid.Sdk.Client.ClientUtils.ParameterToString(scope)); // path parameter
            localVarRequestOptions.PathParameters.Add("code", Lusid.Sdk.Client.ClientUtils.ParameterToString(code)); // path parameter
            localVarRequestOptions.Data = updateComplianceTemplateRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PutAsync<ComplianceRuleTemplate>("/api/compliance/templates/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpdateComplianceTemplate", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRule: Upsert a compliance rule. Use this endpoint to upsert a single compliance rule. The template and variation specified must already  exist, as must the portfolio group. The parameters passed must match those required by the template variation.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRuleRequest"> (optional)</param>
        /// <returns>ComplianceRuleResponse</returns>
        public ComplianceRuleResponse UpsertComplianceRule(UpsertComplianceRuleRequest upsertComplianceRuleRequest = default(UpsertComplianceRuleRequest))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRuleResponse> localVarResponse = UpsertComplianceRuleWithHttpInfo(upsertComplianceRuleRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRule: Upsert a compliance rule. Use this endpoint to upsert a single compliance rule. The template and variation specified must already  exist, as must the portfolio group. The parameters passed must match those required by the template variation.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRuleRequest"> (optional)</param>
        /// <returns>ApiResponse of ComplianceRuleResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<ComplianceRuleResponse> UpsertComplianceRuleWithHttpInfo(UpsertComplianceRuleRequest upsertComplianceRuleRequest = default(UpsertComplianceRuleRequest))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = upsertComplianceRuleRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ComplianceRuleResponse>("/api/compliance/rules", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertComplianceRule", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRule: Upsert a compliance rule. Use this endpoint to upsert a single compliance rule. The template and variation specified must already  exist, as must the portfolio group. The parameters passed must match those required by the template variation.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRuleRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ComplianceRuleResponse</returns>
        public async System.Threading.Tasks.Task<ComplianceRuleResponse> UpsertComplianceRuleAsync(UpsertComplianceRuleRequest upsertComplianceRuleRequest = default(UpsertComplianceRuleRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ComplianceRuleResponse> localVarResponse = await UpsertComplianceRuleWithHttpInfoAsync(upsertComplianceRuleRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRule: Upsert a compliance rule. Use this endpoint to upsert a single compliance rule. The template and variation specified must already  exist, as must the portfolio group. The parameters passed must match those required by the template variation.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRuleRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ComplianceRuleResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ComplianceRuleResponse>> UpsertComplianceRuleWithHttpInfoAsync(UpsertComplianceRuleRequest upsertComplianceRuleRequest = default(UpsertComplianceRuleRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = upsertComplianceRuleRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ComplianceRuleResponse>("/api/compliance/rules", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertComplianceRule", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRunSummary: Upsert a compliance run summary. Use this endpoint to upsert a compliance run result summary.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRunSummaryRequest"> (optional)</param>
        /// <returns>UpsertComplianceRunSummaryResult</returns>
        public UpsertComplianceRunSummaryResult UpsertComplianceRunSummary(UpsertComplianceRunSummaryRequest upsertComplianceRunSummaryRequest = default(UpsertComplianceRunSummaryRequest))
        {
            Lusid.Sdk.Client.ApiResponse<UpsertComplianceRunSummaryResult> localVarResponse = UpsertComplianceRunSummaryWithHttpInfo(upsertComplianceRunSummaryRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRunSummary: Upsert a compliance run summary. Use this endpoint to upsert a compliance run result summary.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRunSummaryRequest"> (optional)</param>
        /// <returns>ApiResponse of UpsertComplianceRunSummaryResult</returns>
        public Lusid.Sdk.Client.ApiResponse<UpsertComplianceRunSummaryResult> UpsertComplianceRunSummaryWithHttpInfo(UpsertComplianceRunSummaryRequest upsertComplianceRunSummaryRequest = default(UpsertComplianceRunSummaryRequest))
        {
            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json",
                "application/json",
                "text/json",
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };

            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = upsertComplianceRunSummaryRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request
            var localVarResponse = this.Client.Post<UpsertComplianceRunSummaryResult>("/api/compliance/runs/summary", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertComplianceRunSummary", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRunSummary: Upsert a compliance run summary. Use this endpoint to upsert a compliance run result summary.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRunSummaryRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of UpsertComplianceRunSummaryResult</returns>
        public async System.Threading.Tasks.Task<UpsertComplianceRunSummaryResult> UpsertComplianceRunSummaryAsync(UpsertComplianceRunSummaryRequest upsertComplianceRunSummaryRequest = default(UpsertComplianceRunSummaryRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<UpsertComplianceRunSummaryResult> localVarResponse = await UpsertComplianceRunSummaryWithHttpInfoAsync(upsertComplianceRunSummaryRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EARLY ACCESS] UpsertComplianceRunSummary: Upsert a compliance run summary. Use this endpoint to upsert a compliance run result summary.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="upsertComplianceRunSummaryRequest"> (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (UpsertComplianceRunSummaryResult)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<UpsertComplianceRunSummaryResult>> UpsertComplianceRunSummaryWithHttpInfoAsync(UpsertComplianceRunSummaryRequest upsertComplianceRunSummaryRequest = default(UpsertComplianceRunSummaryRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Lusid.Sdk.Client.RequestOptions localVarRequestOptions = new Lusid.Sdk.Client.RequestOptions();

            String[] _contentTypes = new String[] {
                "application/json-patch+json", 
                "application/json", 
                "text/json", 
                "application/_*+json"
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "text/plain",
                "application/json",
                "text/json"
            };


            var localVarContentType = Lusid.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = Lusid.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            localVarRequestOptions.Data = upsertComplianceRunSummaryRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.414");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<UpsertComplianceRunSummaryResult>("/api/compliance/runs/summary", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertComplianceRunSummary", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}