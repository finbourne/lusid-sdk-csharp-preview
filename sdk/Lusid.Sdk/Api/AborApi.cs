/*
 * LUSID API
 *
 * # Introduction  This page documents the [LUSID APIs](../../../api/swagger), which allows authorised clients to query and update their data within the LUSID platform.  SDKs to interact with the LUSID APIs are available in the following languages and frameworks:  * [C#](https://github.com/finbourne/lusid-sdk-csharp) * [Java](https://github.com/finbourne/lusid-sdk-java) * [JavaScript](https://github.com/finbourne/lusid-sdk-js) * [Python](https://github.com/finbourne/lusid-sdk-python) * [Angular](https://github.com/finbourne/lusid-sdk-angular)  The LUSID platform is made up of a number of sub-applications. You can find the API / swagger documentation by following the links in the table below.   | Application   | Description                                                                       | API / Swagger Documentation                          | |- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | LUSID         | Open, API-first, developer-friendly investment data platform.                     | [Swagger](../../../api/swagger/index.html)           | | Web app       | User-facing front end for LUSID.                                                  | [Swagger](../../../app/swagger/index.html)           | | Scheduler     | Automated job scheduler.                                                          | [Swagger](../../../scheduler2/swagger/index.html)    | | Insights      | Monitoring and troubleshooting service.                                           | [Swagger](../../../insights/swagger/index.html)      | | Identity      | Identity management for LUSID (in conjunction with Access)                        | [Swagger](../../../identity/swagger/index.html)      | | Access        | Access control for LUSID (in conjunction with Identity)                           | [Swagger](../../../access/swagger/index.html)        | | Drive         | Secure file repository and manager for collaboration.                             | [Swagger](../../../drive/swagger/index.html)         | | Luminesce     | Data virtualisation service (query data from multiple providers, including LUSID) | [Swagger](../../../honeycomb/swagger/index.html)     | | Notification  | Notification service.                                                             | [Swagger](../../../notification/swagger/index.html)  | | Configuration | File store for secrets and other sensitive information.                           | [Swagger](../../../configuration/swagger/index.html) | | Workflow      | Workflow service.                                                                 | [Swagger](../../../workflow/swagger/index.html)      |   # Error Codes  | Code|Name|Description | | - --|- --|- -- | | <a name=\"-10\">-10</a>|Server Configuration Error|  | | <a name=\"-1\">-1</a>|Unknown error|An unexpected error was encountered on our side. | | <a name=\"102\">102</a>|Version Not Found|  | | <a name=\"103\">103</a>|Api Rate Limit Violation|  | | <a name=\"104\">104</a>|Instrument Not Found|  | | <a name=\"105\">105</a>|Property Not Found|  | | <a name=\"106\">106</a>|Portfolio Recursion Depth|  | | <a name=\"108\">108</a>|Group Not Found|  | | <a name=\"109\">109</a>|Portfolio Not Found|  | | <a name=\"110\">110</a>|Property Schema Not Found|  | | <a name=\"111\">111</a>|Portfolio Ancestry Not Found|  | | <a name=\"112\">112</a>|Portfolio With Id Already Exists|  | | <a name=\"113\">113</a>|Orphaned Portfolio|  | | <a name=\"119\">119</a>|Missing Base Claims|  | | <a name=\"121\">121</a>|Property Not Defined|  | | <a name=\"122\">122</a>|Cannot Delete System Property|  | | <a name=\"123\">123</a>|Cannot Modify Immutable Property Field|  | | <a name=\"124\">124</a>|Property Already Exists|  | | <a name=\"125\">125</a>|Invalid Property Life Time|  | | <a name=\"126\">126</a>|Property Constraint Style Excludes Properties|  | | <a name=\"127\">127</a>|Cannot Modify Default Data Type|  | | <a name=\"128\">128</a>|Group Already Exists|  | | <a name=\"129\">129</a>|No Such Data Type|  | | <a name=\"130\">130</a>|Undefined Value For Data Type|  | | <a name=\"131\">131</a>|Unsupported Value Type Defined On Data Type|  | | <a name=\"132\">132</a>|Validation Error|  | | <a name=\"133\">133</a>|Loop Detected In Group Hierarchy|  | | <a name=\"134\">134</a>|Undefined Acceptable Values|  | | <a name=\"135\">135</a>|Sub Group Already Exists|  | | <a name=\"138\">138</a>|Price Source Not Found|  | | <a name=\"139\">139</a>|Analytic Store Not Found|  | | <a name=\"141\">141</a>|Analytic Store Already Exists|  | | <a name=\"143\">143</a>|Client Instrument Already Exists|  | | <a name=\"144\">144</a>|Duplicate In Parameter Set|  | | <a name=\"147\">147</a>|Results Not Found|  | | <a name=\"148\">148</a>|Order Field Not In Result Set|  | | <a name=\"149\">149</a>|Operation Failed|  | | <a name=\"150\">150</a>|Elastic Search Error|  | | <a name=\"151\">151</a>|Invalid Parameter Value|  | | <a name=\"153\">153</a>|Command Processing Failure|  | | <a name=\"154\">154</a>|Entity State Construction Failure|  | | <a name=\"155\">155</a>|Entity Timeline Does Not Exist|  | | <a name=\"156\">156</a>|Concurrency Conflict Failure|  | | <a name=\"157\">157</a>|Invalid Request|  | | <a name=\"158\">158</a>|Event Publish Unknown|  | | <a name=\"159\">159</a>|Event Query Failure|  | | <a name=\"160\">160</a>|Blob Did Not Exist|  | | <a name=\"162\">162</a>|Sub System Request Failure|  | | <a name=\"163\">163</a>|Sub System Configuration Failure|  | | <a name=\"165\">165</a>|Failed To Delete|  | | <a name=\"166\">166</a>|Upsert Client Instrument Failure|  | | <a name=\"167\">167</a>|Illegal As At Interval|  | | <a name=\"168\">168</a>|Illegal Bitemporal Query|  | | <a name=\"169\">169</a>|Invalid Alternate Id|  | | <a name=\"170\">170</a>|Cannot Add Source Portfolio Property Explicitly|  | | <a name=\"171\">171</a>|Entity Already Exists In Group|  | | <a name=\"172\">172</a>|Entity With Id Does Not Exist|  | | <a name=\"173\">173</a>|Entity With Id Already Exists|  | | <a name=\"174\">174</a>|Derived Portfolio Details Do Not Exist|  | | <a name=\"175\">175</a>|Entity Not In Group|  | | <a name=\"176\">176</a>|Portfolio With Name Already Exists|  | | <a name=\"177\">177</a>|Invalid Transactions|  | | <a name=\"178\">178</a>|Reference Portfolio Not Found|  | | <a name=\"179\">179</a>|Duplicate Id|  | | <a name=\"180\">180</a>|Command Retrieval Failure|  | | <a name=\"181\">181</a>|Data Filter Application Failure|  | | <a name=\"182\">182</a>|Search Failed|  | | <a name=\"183\">183</a>|Movements Engine Configuration Key Failure|  | | <a name=\"184\">184</a>|Fx Rate Source Not Found|  | | <a name=\"185\">185</a>|Accrual Source Not Found|  | | <a name=\"186\">186</a>|Access Denied|  | | <a name=\"187\">187</a>|Invalid Identity Token|  | | <a name=\"188\">188</a>|Invalid Request Headers|  | | <a name=\"189\">189</a>|Price Not Found|  | | <a name=\"190\">190</a>|Invalid Sub Holding Keys Provided|  | | <a name=\"191\">191</a>|Duplicate Sub Holding Keys Provided|  | | <a name=\"192\">192</a>|Cut Definition Not Found|  | | <a name=\"193\">193</a>|Cut Definition Invalid|  | | <a name=\"194\">194</a>|Time Variant Property Deletion Date Unspecified|  | | <a name=\"195\">195</a>|Perpetual Property Deletion Date Specified|  | | <a name=\"196\">196</a>|Time Variant Property Upsert Date Unspecified|  | | <a name=\"197\">197</a>|Perpetual Property Upsert Date Specified|  | | <a name=\"200\">200</a>|Invalid Unit For Data Type|  | | <a name=\"201\">201</a>|Invalid Type For Data Type|  | | <a name=\"202\">202</a>|Invalid Value For Data Type|  | | <a name=\"203\">203</a>|Unit Not Defined For Data Type|  | | <a name=\"204\">204</a>|Units Not Supported On Data Type|  | | <a name=\"205\">205</a>|Cannot Specify Units On Data Type|  | | <a name=\"206\">206</a>|Unit Schema Inconsistent With Data Type|  | | <a name=\"207\">207</a>|Unit Definition Not Specified|  | | <a name=\"208\">208</a>|Duplicate Unit Definitions Specified|  | | <a name=\"209\">209</a>|Invalid Units Definition|  | | <a name=\"210\">210</a>|Invalid Instrument Identifier Unit|  | | <a name=\"211\">211</a>|Holdings Adjustment Does Not Exist|  | | <a name=\"212\">212</a>|Could Not Build Excel Url|  | | <a name=\"213\">213</a>|Could Not Get Excel Version|  | | <a name=\"214\">214</a>|Instrument By Code Not Found|  | | <a name=\"215\">215</a>|Entity Schema Does Not Exist|  | | <a name=\"216\">216</a>|Feature Not Supported On Portfolio Type|  | | <a name=\"217\">217</a>|Quote Not Found|  | | <a name=\"218\">218</a>|Invalid Quote Identifier|  | | <a name=\"219\">219</a>|Invalid Metric For Data Type|  | | <a name=\"220\">220</a>|Invalid Instrument Definition|  | | <a name=\"221\">221</a>|Instrument Upsert Failure|  | | <a name=\"222\">222</a>|Reference Portfolio Request Not Supported|  | | <a name=\"223\">223</a>|Transaction Portfolio Request Not Supported|  | | <a name=\"224\">224</a>|Invalid Property Value Assignment|  | | <a name=\"230\">230</a>|Transaction Type Not Found|  | | <a name=\"231\">231</a>|Transaction Type Duplication|  | | <a name=\"232\">232</a>|Portfolio Does Not Exist At Given Date|  | | <a name=\"233\">233</a>|Query Parser Failure|  | | <a name=\"234\">234</a>|Duplicate Constituent|  | | <a name=\"235\">235</a>|Unresolved Instrument Constituent|  | | <a name=\"236\">236</a>|Unresolved Instrument In Transition|  | | <a name=\"237\">237</a>|Missing Side Definitions|  | | <a name=\"240\">240</a>|Duplicate Calculations Failure|  | | <a name=\"299\">299</a>|Invalid Recipe|  | | <a name=\"300\">300</a>|Missing Recipe|  | | <a name=\"301\">301</a>|Dependencies|  | | <a name=\"304\">304</a>|Portfolio Preprocess Failure|  | | <a name=\"310\">310</a>|Valuation Engine Failure|  | | <a name=\"311\">311</a>|Task Factory Failure|  | | <a name=\"312\">312</a>|Task Evaluation Failure|  | | <a name=\"313\">313</a>|Task Generation Failure|  | | <a name=\"314\">314</a>|Engine Configuration Failure|  | | <a name=\"315\">315</a>|Model Specification Failure|  | | <a name=\"320\">320</a>|Market Data Key Failure|  | | <a name=\"321\">321</a>|Market Resolver Failure|  | | <a name=\"322\">322</a>|Market Data Failure|  | | <a name=\"330\">330</a>|Curve Failure|  | | <a name=\"331\">331</a>|Volatility Surface Failure|  | | <a name=\"332\">332</a>|Volatility Cube Failure|  | | <a name=\"350\">350</a>|Instrument Failure|  | | <a name=\"351\">351</a>|Cash Flows Failure|  | | <a name=\"352\">352</a>|Reference Data Failure|  | | <a name=\"360\">360</a>|Aggregation Failure|  | | <a name=\"361\">361</a>|Aggregation Measure Failure|  | | <a name=\"370\">370</a>|Result Retrieval Failure|  | | <a name=\"371\">371</a>|Result Processing Failure|  | | <a name=\"372\">372</a>|Vendor Result Processing Failure|  | | <a name=\"373\">373</a>|Vendor Result Mapping Failure|  | | <a name=\"374\">374</a>|Vendor Library Unauthorised|  | | <a name=\"375\">375</a>|Vendor Connectivity Error|  | | <a name=\"376\">376</a>|Vendor Interface Error|  | | <a name=\"377\">377</a>|Vendor Pricing Failure|  | | <a name=\"378\">378</a>|Vendor Translation Failure|  | | <a name=\"379\">379</a>|Vendor Key Mapping Failure|  | | <a name=\"380\">380</a>|Vendor Reflection Failure|  | | <a name=\"381\">381</a>|Vendor Process Failure|  | | <a name=\"382\">382</a>|Vendor System Failure|  | | <a name=\"390\">390</a>|Attempt To Upsert Duplicate Quotes|  | | <a name=\"391\">391</a>|Corporate Action Source Does Not Exist|  | | <a name=\"392\">392</a>|Corporate Action Source Already Exists|  | | <a name=\"393\">393</a>|Instrument Identifier Already In Use|  | | <a name=\"394\">394</a>|Properties Not Found|  | | <a name=\"395\">395</a>|Batch Operation Aborted|  | | <a name=\"400\">400</a>|Invalid Iso4217 Currency Code|  | | <a name=\"401\">401</a>|Cannot Assign Instrument Identifier To Currency|  | | <a name=\"402\">402</a>|Cannot Assign Currency Identifier To Non Currency|  | | <a name=\"403\">403</a>|Currency Instrument Cannot Be Deleted|  | | <a name=\"404\">404</a>|Currency Instrument Cannot Have Economic Definition|  | | <a name=\"405\">405</a>|Currency Instrument Cannot Have Lookthrough Portfolio|  | | <a name=\"406\">406</a>|Cannot Create Currency Instrument With Multiple Identifiers|  | | <a name=\"407\">407</a>|Specified Currency Is Undefined|  | | <a name=\"410\">410</a>|Index Does Not Exist|  | | <a name=\"411\">411</a>|Sort Field Does Not Exist|  | | <a name=\"413\">413</a>|Negative Pagination Parameters|  | | <a name=\"414\">414</a>|Invalid Search Syntax|  | | <a name=\"415\">415</a>|Filter Execution Timeout|  | | <a name=\"420\">420</a>|Side Definition Inconsistent|  | | <a name=\"450\">450</a>|Invalid Quote Access Metadata Rule|  | | <a name=\"451\">451</a>|Access Metadata Not Found|  | | <a name=\"452\">452</a>|Invalid Access Metadata Identifier|  | | <a name=\"460\">460</a>|Standard Resource Not Found|  | | <a name=\"461\">461</a>|Standard Resource Conflict|  | | <a name=\"462\">462</a>|Calendar Not Found|  | | <a name=\"463\">463</a>|Date In A Calendar Not Found|  | | <a name=\"464\">464</a>|Invalid Date Source Data|  | | <a name=\"465\">465</a>|Invalid Timezone|  | | <a name=\"601\">601</a>|Person Identifier Already In Use|  | | <a name=\"602\">602</a>|Person Not Found|  | | <a name=\"603\">603</a>|Cannot Set Identifier|  | | <a name=\"617\">617</a>|Invalid Recipe Specification In Request|  | | <a name=\"618\">618</a>|Inline Recipe Deserialisation Failure|  | | <a name=\"619\">619</a>|Identifier Types Not Set For Entity|  | | <a name=\"620\">620</a>|Cannot Delete All Client Defined Identifiers|  | | <a name=\"650\">650</a>|The Order requested was not found.|  | | <a name=\"654\">654</a>|The Allocation requested was not found.|  | | <a name=\"655\">655</a>|Cannot build the fx forward target with the given holdings.|  | | <a name=\"656\">656</a>|Group does not contain expected entities.|  | | <a name=\"665\">665</a>|Destination directory not found|  | | <a name=\"667\">667</a>|Relation definition already exists|  | | <a name=\"672\">672</a>|Could not retrieve file contents|  | | <a name=\"673\">673</a>|Missing entitlements for entities in Group|  | | <a name=\"674\">674</a>|Next Best Action not found|  | | <a name=\"676\">676</a>|Relation definition not defined|  | | <a name=\"677\">677</a>|Invalid entity identifier for relation|  | | <a name=\"681\">681</a>|Sorting by specified field not supported|One or more of the provided fields to order by were either invalid or not supported. | | <a name=\"682\">682</a>|Too many fields to sort by|The number of fields to sort the data by exceeds the number allowed by the endpoint | | <a name=\"684\">684</a>|Sequence Not Found|  | | <a name=\"685\">685</a>|Sequence Already Exists|  | | <a name=\"686\">686</a>|Non-cycling sequence has been exhausted|  | | <a name=\"687\">687</a>|Legal Entity Identifier Already In Use|  | | <a name=\"688\">688</a>|Legal Entity Not Found|  | | <a name=\"689\">689</a>|The supplied pagination token is invalid|  | | <a name=\"690\">690</a>|Property Type Is Not Supported|  | | <a name=\"691\">691</a>|Multiple Tax-lots For Currency Type Is Not Supported|  | | <a name=\"692\">692</a>|This endpoint does not support impersonation|  | | <a name=\"693\">693</a>|Entity type is not supported for Relationship|  | | <a name=\"694\">694</a>|Relationship Validation Failure|  | | <a name=\"695\">695</a>|Relationship Not Found|  | | <a name=\"697\">697</a>|Derived Property Formula No Longer Valid|  | | <a name=\"698\">698</a>|Story is not available|  | | <a name=\"703\">703</a>|Corporate Action Does Not Exist|  | | <a name=\"720\">720</a>|The provided sort and filter combination is not valid|  | | <a name=\"721\">721</a>|A2B generation failed|  | | <a name=\"722\">722</a>|Aggregated Return Calculation Failure|  | | <a name=\"723\">723</a>|Custom Entity Definition Identifier Already In Use|  | | <a name=\"724\">724</a>|Custom Entity Definition Not Found|  | | <a name=\"725\">725</a>|The Placement requested was not found.|  | | <a name=\"726\">726</a>|The Execution requested was not found.|  | | <a name=\"727\">727</a>|The Block requested was not found.|  | | <a name=\"728\">728</a>|The Participation requested was not found.|  | | <a name=\"729\">729</a>|The Package requested was not found.|  | | <a name=\"730\">730</a>|The OrderInstruction requested was not found.|  | | <a name=\"732\">732</a>|Custom Entity not found.|  | | <a name=\"733\">733</a>|Custom Entity Identifier already in use.|  | | <a name=\"735\">735</a>|Calculation Failed.|  | | <a name=\"736\">736</a>|An expected key on HttpResponse is missing.|  | | <a name=\"737\">737</a>|A required fee detail is missing.|  | | <a name=\"738\">738</a>|Zero rows were returned from Luminesce|  | | <a name=\"739\">739</a>|Provided Weekend Mask was invalid|  | | <a name=\"742\">742</a>|Custom Entity fields do not match the definition|  | | <a name=\"746\">746</a>|The provided sequence is not valid.|  | | <a name=\"751\">751</a>|The type of the Custom Entity is different than the type provided in the definition.|  | | <a name=\"752\">752</a>|Luminesce process returned an error.|  | | <a name=\"753\">753</a>|File name or content incompatible with operation.|  | | <a name=\"755\">755</a>|Schema of response from Drive is not as expected.|  | | <a name=\"757\">757</a>|Schema of response from Luminesce is not as expected.|  | | <a name=\"758\">758</a>|Luminesce timed out.|  | | <a name=\"763\">763</a>|Invalid Lusid Entity Identifier Unit|  | | <a name=\"768\">768</a>|Fee rule not found.|  | | <a name=\"769\">769</a>|Cannot update the base currency of a portfolio with transactions loaded|  | | <a name=\"771\">771</a>|Transaction configuration source not found|  | | <a name=\"774\">774</a>|Compliance rule not found.|  | | <a name=\"775\">775</a>|Fund accounting document cannot be processed.|  | | <a name=\"778\">778</a>|Unable to look up FX rate from trade ccy to portfolio ccy for some of the trades.|  | | <a name=\"782\">782</a>|The Property definition dataType is not matching the derivation formula dataType|  | | <a name=\"783\">783</a>|The Property definition domain is not supported for derived properties|  | | <a name=\"788\">788</a>|Compliance run not found failure.|  | | <a name=\"790\">790</a>|Custom Entity has missing or invalid identifiers|  | | <a name=\"791\">791</a>|Custom Entity definition already exists|  | | <a name=\"792\">792</a>|Compliance PropertyKey is missing.|  | | <a name=\"793\">793</a>|Compliance Criteria Value for matching is missing.|  | | <a name=\"795\">795</a>|Cannot delete identifier definition|  | | <a name=\"796\">796</a>|Tax rule set not found.|  | | <a name=\"797\">797</a>|A tax rule set with this id already exists.|  | | <a name=\"798\">798</a>|Multiple rule sets for the same property key are applicable.|  | | <a name=\"800\">800</a>|Can not upsert an instrument event of this type.|  | | <a name=\"801\">801</a>|The instrument event does not exist.|  | | <a name=\"802\">802</a>|The Instrument event is missing salient information.|  | | <a name=\"803\">803</a>|The Instrument event could not be processed.|  | | <a name=\"804\">804</a>|Some data requested does not follow the order graph assumptions.|  | | <a name=\"805\">805</a>|The instrument event type does not exist.|  | | <a name=\"806\">806</a>|The transaction template specification does not exist.|  | | <a name=\"807\">807</a>|The default transaction template does not exist.|  | | <a name=\"808\">808</a>|The transaction template does not exist.|  | | <a name=\"811\">811</a>|A price could not be found for an order.|  | | <a name=\"812\">812</a>|A price could not be found for an allocation.|  | | <a name=\"813\">813</a>|Chart of Accounts not found.|  | | <a name=\"814\">814</a>|Account not found.|  | | <a name=\"815\">815</a>|Abor not found.|  | | <a name=\"816\">816</a>|Abor Configuration not found.|  | | <a name=\"817\">817</a>|Reconciliation mapping not found|  | | <a name=\"818\">818</a>|Attribute type could not be deleted because it doesn't exist.|  | | <a name=\"819\">819</a>|Reconciliation not found.|  | | <a name=\"820\">820</a>|Custodian Account not found.|  | | <a name=\"821\">821</a>|Allocation Failure|  | | <a name=\"822\">822</a>|Reconciliation run not found|  | | <a name=\"823\">823</a>|Reconciliation break not found|  | | <a name=\"824\">824</a>|Entity link type could not be deleted because it doesn't exist.|  | | <a name=\"828\">828</a>|Address key definition not found.|  | | <a name=\"829\">829</a>|Compliance template not found.|  | | <a name=\"830\">830</a>|Action not supported|  | | <a name=\"831\">831</a>|Reference list not found.|  | | <a name=\"832\">832</a>|Posting Module not found.|  | | <a name=\"833\">833</a>|The type of parameter provided did not match that required by the compliance rule.|  | | <a name=\"834\">834</a>|The parameters provided by a rule did not match those required by its template.|  | | <a name=\"835\">835</a>|The entity has a property in a domain that is not supprted for that entity type.|  | | <a name=\"836\">836</a>|Structured result data not found.|  | | <a name=\"837\">837</a>|Diary entry not found.|  | | <a name=\"838\">838</a>|Diary entry could not be created.|  | | <a name=\"839\">839</a>|Diary entry already exists.|  | | <a name=\"861\">861</a>|Compliance run summary not found.|  | | <a name=\"869\">869</a>|Conflicting instrument properties in batch.|  | | <a name=\"870\">870</a>|Compliance run summary already exists.|  | | <a name=\"871\">871</a>|The specified impersonated user does not exist|  | | <a name=\"874\">874</a>|Provided Property Domain is not supported for entity filter.|  | | <a name=\"875\">875</a>|Cannot Delete System Reference List.|  | | <a name=\"876\">876</a>|Cleardown Module not found.|  | | <a name=\"879\">879</a>|Portfolios do not have the same base currency|  | | <a name=\"880\">880</a>|There was a problem with the definition of the compliance expression.|  | | <a name=\"881\">881</a>|Block overplaced.|  | | <a name=\"882\">882</a>|Order not approved.|  | 
 *
 * The version of the OpenAPI document: 1.1.201
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
    public interface IAborApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// [EXPERIMENTAL] AddDiaryEntry: Add a diary entry to the specified Abor.
        /// </summary>
        /// <remarks>
        /// Adds a new diary entry to the specified Abor
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="diaryEntryCode">Diary entry code</param>
        /// <param name="diaryEntryRequest">The diary entry to add.</param>
        /// <returns>DiaryEntry</returns>
        DiaryEntry AddDiaryEntry(string scope, string code, string diaryEntryCode, DiaryEntryRequest diaryEntryRequest);

        /// <summary>
        /// [EXPERIMENTAL] AddDiaryEntry: Add a diary entry to the specified Abor.
        /// </summary>
        /// <remarks>
        /// Adds a new diary entry to the specified Abor
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="diaryEntryCode">Diary entry code</param>
        /// <param name="diaryEntryRequest">The diary entry to add.</param>
        /// <returns>ApiResponse of DiaryEntry</returns>
        ApiResponse<DiaryEntry> AddDiaryEntryWithHttpInfo(string scope, string code, string diaryEntryCode, DiaryEntryRequest diaryEntryRequest);
        /// <summary>
        /// [EXPERIMENTAL] ClosePeriod: Closes or locks the current period for the given Abor.
        /// </summary>
        /// <remarks>
        /// Closes or Locks the current open period for the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="closePeriodDiaryEntryRequest">The request body, containing details to apply to the closing/locking period.</param>
        /// <returns>DiaryEntry</returns>
        DiaryEntry ClosePeriod(string scope, string code, ClosePeriodDiaryEntryRequest closePeriodDiaryEntryRequest);

        /// <summary>
        /// [EXPERIMENTAL] ClosePeriod: Closes or locks the current period for the given Abor.
        /// </summary>
        /// <remarks>
        /// Closes or Locks the current open period for the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="closePeriodDiaryEntryRequest">The request body, containing details to apply to the closing/locking period.</param>
        /// <returns>ApiResponse of DiaryEntry</returns>
        ApiResponse<DiaryEntry> ClosePeriodWithHttpInfo(string scope, string code, ClosePeriodDiaryEntryRequest closePeriodDiaryEntryRequest);
        /// <summary>
        /// [EXPERIMENTAL] CreateAbor: Create an Abor.
        /// </summary>
        /// <remarks>
        /// Create the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="aborRequest">The definition of the Abor.</param>
        /// <returns>Abor</returns>
        Abor CreateAbor(string scope, AborRequest aborRequest);

        /// <summary>
        /// [EXPERIMENTAL] CreateAbor: Create an Abor.
        /// </summary>
        /// <remarks>
        /// Create the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="aborRequest">The definition of the Abor.</param>
        /// <returns>ApiResponse of Abor</returns>
        ApiResponse<Abor> CreateAborWithHttpInfo(string scope, AborRequest aborRequest);
        /// <summary>
        /// [EXPERIMENTAL] DeleteAbor: Delete an Abor.
        /// </summary>
        /// <remarks>
        /// Delete the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <returns>DeletedEntityResponse</returns>
        DeletedEntityResponse DeleteAbor(string scope, string code);

        /// <summary>
        /// [EXPERIMENTAL] DeleteAbor: Delete an Abor.
        /// </summary>
        /// <remarks>
        /// Delete the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        ApiResponse<DeletedEntityResponse> DeleteAborWithHttpInfo(string scope, string code);
        /// <summary>
        /// [EXPERIMENTAL] GetAbor: Get Abor.
        /// </summary>
        /// <remarks>
        /// Retrieve the definition of a particular Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Abor properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Abor definition. Defaults to returning the latest version of the Abor definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto the Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. If not provided will return all the entitled properties for that Abor. (optional)</param>
        /// <returns>Abor</returns>
        Abor GetAbor(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>));

        /// <summary>
        /// [EXPERIMENTAL] GetAbor: Get Abor.
        /// </summary>
        /// <remarks>
        /// Retrieve the definition of a particular Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Abor properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Abor definition. Defaults to returning the latest version of the Abor definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto the Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. If not provided will return all the entitled properties for that Abor. (optional)</param>
        /// <returns>ApiResponse of Abor</returns>
        ApiResponse<Abor> GetAborWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>));
        /// <summary>
        /// [DEPRECATED] GetJELines: DEPRECATED: please use GetJournalEntryLines instead. Get the JELines for the given Abor.
        /// </summary>
        /// <remarks>
        /// DEPRECATED: please use GetJournalEntryLines instead. Gets the JELines for the given Abor                The JE Lines have been generated from transactions and translated via posting rules
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="jELinesQueryParameters">The query parameters used in running the generation of the JELines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve JELines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing JELines from a previous call to GetJELines. (optional)</param>
        /// <returns>VersionedResourceListOfJournalEntryLine</returns>
        VersionedResourceListOfJournalEntryLine GetJELines(string scope, string code, JELinesQueryParameters jELinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), int? limit = default(int?), string page = default(string));

        /// <summary>
        /// [DEPRECATED] GetJELines: DEPRECATED: please use GetJournalEntryLines instead. Get the JELines for the given Abor.
        /// </summary>
        /// <remarks>
        /// DEPRECATED: please use GetJournalEntryLines instead. Gets the JELines for the given Abor                The JE Lines have been generated from transactions and translated via posting rules
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="jELinesQueryParameters">The query parameters used in running the generation of the JELines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve JELines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing JELines from a previous call to GetJELines. (optional)</param>
        /// <returns>ApiResponse of VersionedResourceListOfJournalEntryLine</returns>
        ApiResponse<VersionedResourceListOfJournalEntryLine> GetJELinesWithHttpInfo(string scope, string code, JELinesQueryParameters jELinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), int? limit = default(int?), string page = default(string));
        /// <summary>
        /// [EXPERIMENTAL] GetJournalEntryLines: Get the Journal Entry lines for the given Abor.
        /// </summary>
        /// <remarks>
        /// Gets the Journal Entry lines for the given Abor                The Journal Entry lines have been generated from transactions and translated via posting rules
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="journalEntryLinesQueryParameters">The query parameters used in running the generation of the Journal Entry lines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve Journal Entry lines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Journal Entry lines from a previous call to GetJournalEntryLines. (optional)</param>
        /// <returns>VersionedResourceListOfJournalEntryLine</returns>
        VersionedResourceListOfJournalEntryLine GetJournalEntryLines(string scope, string code, JournalEntryLinesQueryParameters journalEntryLinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string));

        /// <summary>
        /// [EXPERIMENTAL] GetJournalEntryLines: Get the Journal Entry lines for the given Abor.
        /// </summary>
        /// <remarks>
        /// Gets the Journal Entry lines for the given Abor                The Journal Entry lines have been generated from transactions and translated via posting rules
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="journalEntryLinesQueryParameters">The query parameters used in running the generation of the Journal Entry lines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve Journal Entry lines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Journal Entry lines from a previous call to GetJournalEntryLines. (optional)</param>
        /// <returns>ApiResponse of VersionedResourceListOfJournalEntryLine</returns>
        ApiResponse<VersionedResourceListOfJournalEntryLine> GetJournalEntryLinesWithHttpInfo(string scope, string code, JournalEntryLinesQueryParameters journalEntryLinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string));
        /// <summary>
        /// [EXPERIMENTAL] GetTrialBalance: Get the Trial balance for the given Abor.
        /// </summary>
        /// <remarks>
        /// Gets the Trial balance for the given Abor    The Trial balance has been generated from transactions, translated via posting rules and aggregated based on a General Ledger Profile (where specified)
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is the unique identifier for the given Abor.</param>
        /// <param name="trialBalanceQueryParameters">The query parameters used in running the generation of the Trial Balance.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve trial balance. Defaults to returning the latest version              of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Trial balance from a previous call to Trial balance. (optional)</param>
        /// <returns>VersionedResourceListOfTrialBalance</returns>
        VersionedResourceListOfTrialBalance GetTrialBalance(string scope, string code, TrialBalanceQueryParameters trialBalanceQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string));

        /// <summary>
        /// [EXPERIMENTAL] GetTrialBalance: Get the Trial balance for the given Abor.
        /// </summary>
        /// <remarks>
        /// Gets the Trial balance for the given Abor    The Trial balance has been generated from transactions, translated via posting rules and aggregated based on a General Ledger Profile (where specified)
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is the unique identifier for the given Abor.</param>
        /// <param name="trialBalanceQueryParameters">The query parameters used in running the generation of the Trial Balance.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve trial balance. Defaults to returning the latest version              of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Trial balance from a previous call to Trial balance. (optional)</param>
        /// <returns>ApiResponse of VersionedResourceListOfTrialBalance</returns>
        ApiResponse<VersionedResourceListOfTrialBalance> GetTrialBalanceWithHttpInfo(string scope, string code, TrialBalanceQueryParameters trialBalanceQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string));
        /// <summary>
        /// [EXPERIMENTAL] ListAbors: List Abors.
        /// </summary>
        /// <remarks>
        /// List all the Abors matching particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Abor. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Abor. Defaults to returning the latest version of each Abor if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Abor; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Abor type, specify \&quot;id.Code eq &#39;Abor1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto each Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. (optional)</param>
        /// <returns>PagedResourceListOfAbor</returns>
        PagedResourceListOfAbor ListAbors(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>));

        /// <summary>
        /// [EXPERIMENTAL] ListAbors: List Abors.
        /// </summary>
        /// <remarks>
        /// List all the Abors matching particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Abor. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Abor. Defaults to returning the latest version of each Abor if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Abor; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Abor type, specify \&quot;id.Code eq &#39;Abor1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto each Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfAbor</returns>
        ApiResponse<PagedResourceListOfAbor> ListAborsWithHttpInfo(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>));
        /// <summary>
        /// [EXPERIMENTAL] ListDiaryEntries: List diary entries.
        /// </summary>
        /// <remarks>
        /// List all the diary entries matching particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Diary Entries. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the DiaryEntry. Defaults to returning the latest version of each DiaryEntry if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing diary entries; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the DiaryEntry type, specify \&quot;type eq &#39;PeriodBoundary&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;DiaryEntry&#39; domain to decorate onto each DiaryEntry.              These must take the format {domain}/{scope}/{code}, for example &#39;DiaryEntry/Report/Id&#39;. (optional)</param>
        /// <returns>PagedResourceListOfDiaryEntry</returns>
        PagedResourceListOfDiaryEntry ListDiaryEntries(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>));

        /// <summary>
        /// [EXPERIMENTAL] ListDiaryEntries: List diary entries.
        /// </summary>
        /// <remarks>
        /// List all the diary entries matching particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Diary Entries. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the DiaryEntry. Defaults to returning the latest version of each DiaryEntry if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing diary entries; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the DiaryEntry type, specify \&quot;type eq &#39;PeriodBoundary&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;DiaryEntry&#39; domain to decorate onto each DiaryEntry.              These must take the format {domain}/{scope}/{code}, for example &#39;DiaryEntry/Report/Id&#39;. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfDiaryEntry</returns>
        ApiResponse<PagedResourceListOfDiaryEntry> ListDiaryEntriesWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>));
        /// <summary>
        /// [EXPERIMENTAL] LockPeriod: Locks the last Closed or given Closed Period.
        /// </summary>
        /// <remarks>
        /// Locks the specified or last locked period for the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="lockPeriodDiaryEntryRequest">The request body, detailing lock details (optional)</param>
        /// <returns>DiaryEntry</returns>
        DiaryEntry LockPeriod(string scope, string code, LockPeriodDiaryEntryRequest lockPeriodDiaryEntryRequest = default(LockPeriodDiaryEntryRequest));

        /// <summary>
        /// [EXPERIMENTAL] LockPeriod: Locks the last Closed or given Closed Period.
        /// </summary>
        /// <remarks>
        /// Locks the specified or last locked period for the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="lockPeriodDiaryEntryRequest">The request body, detailing lock details (optional)</param>
        /// <returns>ApiResponse of DiaryEntry</returns>
        ApiResponse<DiaryEntry> LockPeriodWithHttpInfo(string scope, string code, LockPeriodDiaryEntryRequest lockPeriodDiaryEntryRequest = default(LockPeriodDiaryEntryRequest));
        /// <summary>
        /// [EXPERIMENTAL] ReOpenPeriods: Reopen periods from a seed Diary Entry Code or when not specified, the last Closed Period for the given Abor.
        /// </summary>
        /// <remarks>
        /// Reopens one or more periods.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="reOpenPeriodDiaryEntryRequest">The request body, detailing re open details (optional)</param>
        /// <returns>PeriodDiaryEntriesReopenedResponse</returns>
        PeriodDiaryEntriesReopenedResponse ReOpenPeriods(string scope, string code, ReOpenPeriodDiaryEntryRequest reOpenPeriodDiaryEntryRequest = default(ReOpenPeriodDiaryEntryRequest));

        /// <summary>
        /// [EXPERIMENTAL] ReOpenPeriods: Reopen periods from a seed Diary Entry Code or when not specified, the last Closed Period for the given Abor.
        /// </summary>
        /// <remarks>
        /// Reopens one or more periods.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="reOpenPeriodDiaryEntryRequest">The request body, detailing re open details (optional)</param>
        /// <returns>ApiResponse of PeriodDiaryEntriesReopenedResponse</returns>
        ApiResponse<PeriodDiaryEntriesReopenedResponse> ReOpenPeriodsWithHttpInfo(string scope, string code, ReOpenPeriodDiaryEntryRequest reOpenPeriodDiaryEntryRequest = default(ReOpenPeriodDiaryEntryRequest));
        /// <summary>
        /// [EXPERIMENTAL] UpsertAborProperties: Upsert Abor properties
        /// </summary>
        /// <remarks>
        /// Update or insert one or more properties onto a single Abor. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Abor&#39;.                Upserting a property that exists for an Abor, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to update or insert the properties onto.</param>
        /// <param name="code">The code of the Abor to update or insert the properties onto. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Abor. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Abor/Manager/Id\&quot;. (optional)</param>
        /// <returns>AborProperties</returns>
        AborProperties UpsertAborProperties(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>));

        /// <summary>
        /// [EXPERIMENTAL] UpsertAborProperties: Upsert Abor properties
        /// </summary>
        /// <remarks>
        /// Update or insert one or more properties onto a single Abor. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Abor&#39;.                Upserting a property that exists for an Abor, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to update or insert the properties onto.</param>
        /// <param name="code">The code of the Abor to update or insert the properties onto. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Abor. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Abor/Manager/Id\&quot;. (optional)</param>
        /// <returns>ApiResponse of AborProperties</returns>
        ApiResponse<AborProperties> UpsertAborPropertiesWithHttpInfo(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAborApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// [EXPERIMENTAL] AddDiaryEntry: Add a diary entry to the specified Abor.
        /// </summary>
        /// <remarks>
        /// Adds a new diary entry to the specified Abor
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="diaryEntryCode">Diary entry code</param>
        /// <param name="diaryEntryRequest">The diary entry to add.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DiaryEntry</returns>
        System.Threading.Tasks.Task<DiaryEntry> AddDiaryEntryAsync(string scope, string code, string diaryEntryCode, DiaryEntryRequest diaryEntryRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] AddDiaryEntry: Add a diary entry to the specified Abor.
        /// </summary>
        /// <remarks>
        /// Adds a new diary entry to the specified Abor
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="diaryEntryCode">Diary entry code</param>
        /// <param name="diaryEntryRequest">The diary entry to add.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DiaryEntry)</returns>
        System.Threading.Tasks.Task<ApiResponse<DiaryEntry>> AddDiaryEntryWithHttpInfoAsync(string scope, string code, string diaryEntryCode, DiaryEntryRequest diaryEntryRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] ClosePeriod: Closes or locks the current period for the given Abor.
        /// </summary>
        /// <remarks>
        /// Closes or Locks the current open period for the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="closePeriodDiaryEntryRequest">The request body, containing details to apply to the closing/locking period.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DiaryEntry</returns>
        System.Threading.Tasks.Task<DiaryEntry> ClosePeriodAsync(string scope, string code, ClosePeriodDiaryEntryRequest closePeriodDiaryEntryRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] ClosePeriod: Closes or locks the current period for the given Abor.
        /// </summary>
        /// <remarks>
        /// Closes or Locks the current open period for the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="closePeriodDiaryEntryRequest">The request body, containing details to apply to the closing/locking period.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DiaryEntry)</returns>
        System.Threading.Tasks.Task<ApiResponse<DiaryEntry>> ClosePeriodWithHttpInfoAsync(string scope, string code, ClosePeriodDiaryEntryRequest closePeriodDiaryEntryRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] CreateAbor: Create an Abor.
        /// </summary>
        /// <remarks>
        /// Create the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="aborRequest">The definition of the Abor.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Abor</returns>
        System.Threading.Tasks.Task<Abor> CreateAborAsync(string scope, AborRequest aborRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] CreateAbor: Create an Abor.
        /// </summary>
        /// <remarks>
        /// Create the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="aborRequest">The definition of the Abor.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Abor)</returns>
        System.Threading.Tasks.Task<ApiResponse<Abor>> CreateAborWithHttpInfoAsync(string scope, AborRequest aborRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] DeleteAbor: Delete an Abor.
        /// </summary>
        /// <remarks>
        /// Delete the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        System.Threading.Tasks.Task<DeletedEntityResponse> DeleteAborAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] DeleteAbor: Delete an Abor.
        /// </summary>
        /// <remarks>
        /// Delete the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeletedEntityResponse>> DeleteAborWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] GetAbor: Get Abor.
        /// </summary>
        /// <remarks>
        /// Retrieve the definition of a particular Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Abor properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Abor definition. Defaults to returning the latest version of the Abor definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto the Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. If not provided will return all the entitled properties for that Abor. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Abor</returns>
        System.Threading.Tasks.Task<Abor> GetAborAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] GetAbor: Get Abor.
        /// </summary>
        /// <remarks>
        /// Retrieve the definition of a particular Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Abor properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Abor definition. Defaults to returning the latest version of the Abor definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto the Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. If not provided will return all the entitled properties for that Abor. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Abor)</returns>
        System.Threading.Tasks.Task<ApiResponse<Abor>> GetAborWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [DEPRECATED] GetJELines: DEPRECATED: please use GetJournalEntryLines instead. Get the JELines for the given Abor.
        /// </summary>
        /// <remarks>
        /// DEPRECATED: please use GetJournalEntryLines instead. Gets the JELines for the given Abor                The JE Lines have been generated from transactions and translated via posting rules
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="jELinesQueryParameters">The query parameters used in running the generation of the JELines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve JELines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing JELines from a previous call to GetJELines. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VersionedResourceListOfJournalEntryLine</returns>
        System.Threading.Tasks.Task<VersionedResourceListOfJournalEntryLine> GetJELinesAsync(string scope, string code, JELinesQueryParameters jELinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), int? limit = default(int?), string page = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [DEPRECATED] GetJELines: DEPRECATED: please use GetJournalEntryLines instead. Get the JELines for the given Abor.
        /// </summary>
        /// <remarks>
        /// DEPRECATED: please use GetJournalEntryLines instead. Gets the JELines for the given Abor                The JE Lines have been generated from transactions and translated via posting rules
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="jELinesQueryParameters">The query parameters used in running the generation of the JELines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve JELines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing JELines from a previous call to GetJELines. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VersionedResourceListOfJournalEntryLine)</returns>
        System.Threading.Tasks.Task<ApiResponse<VersionedResourceListOfJournalEntryLine>> GetJELinesWithHttpInfoAsync(string scope, string code, JELinesQueryParameters jELinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), int? limit = default(int?), string page = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] GetJournalEntryLines: Get the Journal Entry lines for the given Abor.
        /// </summary>
        /// <remarks>
        /// Gets the Journal Entry lines for the given Abor                The Journal Entry lines have been generated from transactions and translated via posting rules
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="journalEntryLinesQueryParameters">The query parameters used in running the generation of the Journal Entry lines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve Journal Entry lines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Journal Entry lines from a previous call to GetJournalEntryLines. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VersionedResourceListOfJournalEntryLine</returns>
        System.Threading.Tasks.Task<VersionedResourceListOfJournalEntryLine> GetJournalEntryLinesAsync(string scope, string code, JournalEntryLinesQueryParameters journalEntryLinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] GetJournalEntryLines: Get the Journal Entry lines for the given Abor.
        /// </summary>
        /// <remarks>
        /// Gets the Journal Entry lines for the given Abor                The Journal Entry lines have been generated from transactions and translated via posting rules
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="journalEntryLinesQueryParameters">The query parameters used in running the generation of the Journal Entry lines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve Journal Entry lines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Journal Entry lines from a previous call to GetJournalEntryLines. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VersionedResourceListOfJournalEntryLine)</returns>
        System.Threading.Tasks.Task<ApiResponse<VersionedResourceListOfJournalEntryLine>> GetJournalEntryLinesWithHttpInfoAsync(string scope, string code, JournalEntryLinesQueryParameters journalEntryLinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] GetTrialBalance: Get the Trial balance for the given Abor.
        /// </summary>
        /// <remarks>
        /// Gets the Trial balance for the given Abor    The Trial balance has been generated from transactions, translated via posting rules and aggregated based on a General Ledger Profile (where specified)
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is the unique identifier for the given Abor.</param>
        /// <param name="trialBalanceQueryParameters">The query parameters used in running the generation of the Trial Balance.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve trial balance. Defaults to returning the latest version              of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Trial balance from a previous call to Trial balance. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VersionedResourceListOfTrialBalance</returns>
        System.Threading.Tasks.Task<VersionedResourceListOfTrialBalance> GetTrialBalanceAsync(string scope, string code, TrialBalanceQueryParameters trialBalanceQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] GetTrialBalance: Get the Trial balance for the given Abor.
        /// </summary>
        /// <remarks>
        /// Gets the Trial balance for the given Abor    The Trial balance has been generated from transactions, translated via posting rules and aggregated based on a General Ledger Profile (where specified)
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is the unique identifier for the given Abor.</param>
        /// <param name="trialBalanceQueryParameters">The query parameters used in running the generation of the Trial Balance.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve trial balance. Defaults to returning the latest version              of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Trial balance from a previous call to Trial balance. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VersionedResourceListOfTrialBalance)</returns>
        System.Threading.Tasks.Task<ApiResponse<VersionedResourceListOfTrialBalance>> GetTrialBalanceWithHttpInfoAsync(string scope, string code, TrialBalanceQueryParameters trialBalanceQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] ListAbors: List Abors.
        /// </summary>
        /// <remarks>
        /// List all the Abors matching particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Abor. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Abor. Defaults to returning the latest version of each Abor if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Abor; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Abor type, specify \&quot;id.Code eq &#39;Abor1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto each Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfAbor</returns>
        System.Threading.Tasks.Task<PagedResourceListOfAbor> ListAborsAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] ListAbors: List Abors.
        /// </summary>
        /// <remarks>
        /// List all the Abors matching particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Abor. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Abor. Defaults to returning the latest version of each Abor if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Abor; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Abor type, specify \&quot;id.Code eq &#39;Abor1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto each Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfAbor)</returns>
        System.Threading.Tasks.Task<ApiResponse<PagedResourceListOfAbor>> ListAborsWithHttpInfoAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] ListDiaryEntries: List diary entries.
        /// </summary>
        /// <remarks>
        /// List all the diary entries matching particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Diary Entries. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the DiaryEntry. Defaults to returning the latest version of each DiaryEntry if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing diary entries; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the DiaryEntry type, specify \&quot;type eq &#39;PeriodBoundary&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;DiaryEntry&#39; domain to decorate onto each DiaryEntry.              These must take the format {domain}/{scope}/{code}, for example &#39;DiaryEntry/Report/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfDiaryEntry</returns>
        System.Threading.Tasks.Task<PagedResourceListOfDiaryEntry> ListDiaryEntriesAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] ListDiaryEntries: List diary entries.
        /// </summary>
        /// <remarks>
        /// List all the diary entries matching particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Diary Entries. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the DiaryEntry. Defaults to returning the latest version of each DiaryEntry if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing diary entries; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the DiaryEntry type, specify \&quot;type eq &#39;PeriodBoundary&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;DiaryEntry&#39; domain to decorate onto each DiaryEntry.              These must take the format {domain}/{scope}/{code}, for example &#39;DiaryEntry/Report/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfDiaryEntry)</returns>
        System.Threading.Tasks.Task<ApiResponse<PagedResourceListOfDiaryEntry>> ListDiaryEntriesWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] LockPeriod: Locks the last Closed or given Closed Period.
        /// </summary>
        /// <remarks>
        /// Locks the specified or last locked period for the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="lockPeriodDiaryEntryRequest">The request body, detailing lock details (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DiaryEntry</returns>
        System.Threading.Tasks.Task<DiaryEntry> LockPeriodAsync(string scope, string code, LockPeriodDiaryEntryRequest lockPeriodDiaryEntryRequest = default(LockPeriodDiaryEntryRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] LockPeriod: Locks the last Closed or given Closed Period.
        /// </summary>
        /// <remarks>
        /// Locks the specified or last locked period for the given Abor.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="lockPeriodDiaryEntryRequest">The request body, detailing lock details (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DiaryEntry)</returns>
        System.Threading.Tasks.Task<ApiResponse<DiaryEntry>> LockPeriodWithHttpInfoAsync(string scope, string code, LockPeriodDiaryEntryRequest lockPeriodDiaryEntryRequest = default(LockPeriodDiaryEntryRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] ReOpenPeriods: Reopen periods from a seed Diary Entry Code or when not specified, the last Closed Period for the given Abor.
        /// </summary>
        /// <remarks>
        /// Reopens one or more periods.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="reOpenPeriodDiaryEntryRequest">The request body, detailing re open details (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PeriodDiaryEntriesReopenedResponse</returns>
        System.Threading.Tasks.Task<PeriodDiaryEntriesReopenedResponse> ReOpenPeriodsAsync(string scope, string code, ReOpenPeriodDiaryEntryRequest reOpenPeriodDiaryEntryRequest = default(ReOpenPeriodDiaryEntryRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] ReOpenPeriods: Reopen periods from a seed Diary Entry Code or when not specified, the last Closed Period for the given Abor.
        /// </summary>
        /// <remarks>
        /// Reopens one or more periods.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="reOpenPeriodDiaryEntryRequest">The request body, detailing re open details (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PeriodDiaryEntriesReopenedResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<PeriodDiaryEntriesReopenedResponse>> ReOpenPeriodsWithHttpInfoAsync(string scope, string code, ReOpenPeriodDiaryEntryRequest reOpenPeriodDiaryEntryRequest = default(ReOpenPeriodDiaryEntryRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] UpsertAborProperties: Upsert Abor properties
        /// </summary>
        /// <remarks>
        /// Update or insert one or more properties onto a single Abor. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Abor&#39;.                Upserting a property that exists for an Abor, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to update or insert the properties onto.</param>
        /// <param name="code">The code of the Abor to update or insert the properties onto. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Abor. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Abor/Manager/Id\&quot;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AborProperties</returns>
        System.Threading.Tasks.Task<AborProperties> UpsertAborPropertiesAsync(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] UpsertAborProperties: Upsert Abor properties
        /// </summary>
        /// <remarks>
        /// Update or insert one or more properties onto a single Abor. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Abor&#39;.                Upserting a property that exists for an Abor, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to update or insert the properties onto.</param>
        /// <param name="code">The code of the Abor to update or insert the properties onto. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Abor. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Abor/Manager/Id\&quot;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AborProperties)</returns>
        System.Threading.Tasks.Task<ApiResponse<AborProperties>> UpsertAborPropertiesWithHttpInfoAsync(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IAborApi : IAborApiSync, IAborApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class AborApi : IAborApi
    {
        private Lusid.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AborApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AborApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AborApi"/> class.
        /// </summary>
        /// <returns></returns>
        public AborApi(String basePath)
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
        /// Initializes a new instance of the <see cref="AborApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public AborApi(Lusid.Sdk.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = configuration;
            this.Client = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Lusid.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AborApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public AborApi(Lusid.Sdk.Client.ISynchronousClient client, Lusid.Sdk.Client.IAsynchronousClient asyncClient, Lusid.Sdk.Client.IReadableConfiguration configuration)
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
        /// [EXPERIMENTAL] AddDiaryEntry: Add a diary entry to the specified Abor. Adds a new diary entry to the specified Abor
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="diaryEntryCode">Diary entry code</param>
        /// <param name="diaryEntryRequest">The diary entry to add.</param>
        /// <returns>DiaryEntry</returns>
        public DiaryEntry AddDiaryEntry(string scope, string code, string diaryEntryCode, DiaryEntryRequest diaryEntryRequest)
        {
            Lusid.Sdk.Client.ApiResponse<DiaryEntry> localVarResponse = AddDiaryEntryWithHttpInfo(scope, code, diaryEntryCode, diaryEntryRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] AddDiaryEntry: Add a diary entry to the specified Abor. Adds a new diary entry to the specified Abor
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="diaryEntryCode">Diary entry code</param>
        /// <param name="diaryEntryRequest">The diary entry to add.</param>
        /// <returns>ApiResponse of DiaryEntry</returns>
        public Lusid.Sdk.Client.ApiResponse<DiaryEntry> AddDiaryEntryWithHttpInfo(string scope, string code, string diaryEntryCode, DiaryEntryRequest diaryEntryRequest)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->AddDiaryEntry");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->AddDiaryEntry");

            // verify the required parameter 'diaryEntryCode' is set
            if (diaryEntryCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'diaryEntryCode' when calling AborApi->AddDiaryEntry");

            // verify the required parameter 'diaryEntryRequest' is set
            if (diaryEntryRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'diaryEntryRequest' when calling AborApi->AddDiaryEntry");

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
            localVarRequestOptions.PathParameters.Add("diaryEntryCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(diaryEntryCode)); // path parameter
            localVarRequestOptions.Data = diaryEntryRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request
            var localVarResponse = this.Client.Post<DiaryEntry>("/api/abor/{scope}/{code}/accountingdiary/{diaryEntryCode}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AddDiaryEntry", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] AddDiaryEntry: Add a diary entry to the specified Abor. Adds a new diary entry to the specified Abor
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="diaryEntryCode">Diary entry code</param>
        /// <param name="diaryEntryRequest">The diary entry to add.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DiaryEntry</returns>
        public async System.Threading.Tasks.Task<DiaryEntry> AddDiaryEntryAsync(string scope, string code, string diaryEntryCode, DiaryEntryRequest diaryEntryRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DiaryEntry> localVarResponse = await AddDiaryEntryWithHttpInfoAsync(scope, code, diaryEntryCode, diaryEntryRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] AddDiaryEntry: Add a diary entry to the specified Abor. Adds a new diary entry to the specified Abor
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="diaryEntryCode">Diary entry code</param>
        /// <param name="diaryEntryRequest">The diary entry to add.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DiaryEntry)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DiaryEntry>> AddDiaryEntryWithHttpInfoAsync(string scope, string code, string diaryEntryCode, DiaryEntryRequest diaryEntryRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->AddDiaryEntry");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->AddDiaryEntry");

            // verify the required parameter 'diaryEntryCode' is set
            if (diaryEntryCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'diaryEntryCode' when calling AborApi->AddDiaryEntry");

            // verify the required parameter 'diaryEntryRequest' is set
            if (diaryEntryRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'diaryEntryRequest' when calling AborApi->AddDiaryEntry");


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
            localVarRequestOptions.PathParameters.Add("diaryEntryCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(diaryEntryCode)); // path parameter
            localVarRequestOptions.Data = diaryEntryRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<DiaryEntry>("/api/abor/{scope}/{code}/accountingdiary/{diaryEntryCode}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AddDiaryEntry", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ClosePeriod: Closes or locks the current period for the given Abor. Closes or Locks the current open period for the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="closePeriodDiaryEntryRequest">The request body, containing details to apply to the closing/locking period.</param>
        /// <returns>DiaryEntry</returns>
        public DiaryEntry ClosePeriod(string scope, string code, ClosePeriodDiaryEntryRequest closePeriodDiaryEntryRequest)
        {
            Lusid.Sdk.Client.ApiResponse<DiaryEntry> localVarResponse = ClosePeriodWithHttpInfo(scope, code, closePeriodDiaryEntryRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ClosePeriod: Closes or locks the current period for the given Abor. Closes or Locks the current open period for the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="closePeriodDiaryEntryRequest">The request body, containing details to apply to the closing/locking period.</param>
        /// <returns>ApiResponse of DiaryEntry</returns>
        public Lusid.Sdk.Client.ApiResponse<DiaryEntry> ClosePeriodWithHttpInfo(string scope, string code, ClosePeriodDiaryEntryRequest closePeriodDiaryEntryRequest)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->ClosePeriod");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->ClosePeriod");

            // verify the required parameter 'closePeriodDiaryEntryRequest' is set
            if (closePeriodDiaryEntryRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'closePeriodDiaryEntryRequest' when calling AborApi->ClosePeriod");

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
            localVarRequestOptions.Data = closePeriodDiaryEntryRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request
            var localVarResponse = this.Client.Post<DiaryEntry>("/api/abor/{scope}/{code}/accountingdiary/$closeperiod", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ClosePeriod", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ClosePeriod: Closes or locks the current period for the given Abor. Closes or Locks the current open period for the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="closePeriodDiaryEntryRequest">The request body, containing details to apply to the closing/locking period.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DiaryEntry</returns>
        public async System.Threading.Tasks.Task<DiaryEntry> ClosePeriodAsync(string scope, string code, ClosePeriodDiaryEntryRequest closePeriodDiaryEntryRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DiaryEntry> localVarResponse = await ClosePeriodWithHttpInfoAsync(scope, code, closePeriodDiaryEntryRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ClosePeriod: Closes or locks the current period for the given Abor. Closes or Locks the current open period for the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="closePeriodDiaryEntryRequest">The request body, containing details to apply to the closing/locking period.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DiaryEntry)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DiaryEntry>> ClosePeriodWithHttpInfoAsync(string scope, string code, ClosePeriodDiaryEntryRequest closePeriodDiaryEntryRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->ClosePeriod");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->ClosePeriod");

            // verify the required parameter 'closePeriodDiaryEntryRequest' is set
            if (closePeriodDiaryEntryRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'closePeriodDiaryEntryRequest' when calling AborApi->ClosePeriod");


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
            localVarRequestOptions.Data = closePeriodDiaryEntryRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<DiaryEntry>("/api/abor/{scope}/{code}/accountingdiary/$closeperiod", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ClosePeriod", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateAbor: Create an Abor. Create the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="aborRequest">The definition of the Abor.</param>
        /// <returns>Abor</returns>
        public Abor CreateAbor(string scope, AborRequest aborRequest)
        {
            Lusid.Sdk.Client.ApiResponse<Abor> localVarResponse = CreateAborWithHttpInfo(scope, aborRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateAbor: Create an Abor. Create the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="aborRequest">The definition of the Abor.</param>
        /// <returns>ApiResponse of Abor</returns>
        public Lusid.Sdk.Client.ApiResponse<Abor> CreateAborWithHttpInfo(string scope, AborRequest aborRequest)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->CreateAbor");

            // verify the required parameter 'aborRequest' is set
            if (aborRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'aborRequest' when calling AborApi->CreateAbor");

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
            localVarRequestOptions.Data = aborRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request
            var localVarResponse = this.Client.Post<Abor>("/api/abor/{scope}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateAbor", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateAbor: Create an Abor. Create the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="aborRequest">The definition of the Abor.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Abor</returns>
        public async System.Threading.Tasks.Task<Abor> CreateAborAsync(string scope, AborRequest aborRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<Abor> localVarResponse = await CreateAborWithHttpInfoAsync(scope, aborRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateAbor: Create an Abor. Create the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="aborRequest">The definition of the Abor.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Abor)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<Abor>> CreateAborWithHttpInfoAsync(string scope, AborRequest aborRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->CreateAbor");

            // verify the required parameter 'aborRequest' is set
            if (aborRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'aborRequest' when calling AborApi->CreateAbor");


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
            localVarRequestOptions.Data = aborRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Abor>("/api/abor/{scope}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateAbor", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteAbor: Delete an Abor. Delete the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <returns>DeletedEntityResponse</returns>
        public DeletedEntityResponse DeleteAbor(string scope, string code)
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = DeleteAborWithHttpInfo(scope, code);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteAbor: Delete an Abor. Delete the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> DeleteAborWithHttpInfo(string scope, string code)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->DeleteAbor");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->DeleteAbor");

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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request
            var localVarResponse = this.Client.Delete<DeletedEntityResponse>("/api/abor/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteAbor", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteAbor: Delete an Abor. Delete the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        public async System.Threading.Tasks.Task<DeletedEntityResponse> DeleteAborAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = await DeleteAborWithHttpInfoAsync(scope, code, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteAbor: Delete an Abor. Delete the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse>> DeleteAborWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->DeleteAbor");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->DeleteAbor");


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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<DeletedEntityResponse>("/api/abor/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteAbor", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetAbor: Get Abor. Retrieve the definition of a particular Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Abor properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Abor definition. Defaults to returning the latest version of the Abor definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto the Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. If not provided will return all the entitled properties for that Abor. (optional)</param>
        /// <returns>Abor</returns>
        public Abor GetAbor(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>))
        {
            Lusid.Sdk.Client.ApiResponse<Abor> localVarResponse = GetAborWithHttpInfo(scope, code, effectiveAt, asAt, propertyKeys);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetAbor: Get Abor. Retrieve the definition of a particular Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Abor properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Abor definition. Defaults to returning the latest version of the Abor definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto the Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. If not provided will return all the entitled properties for that Abor. (optional)</param>
        /// <returns>ApiResponse of Abor</returns>
        public Lusid.Sdk.Client.ApiResponse<Abor> GetAborWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->GetAbor");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->GetAbor");

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
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request
            var localVarResponse = this.Client.Get<Abor>("/api/abor/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAbor", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetAbor: Get Abor. Retrieve the definition of a particular Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Abor properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Abor definition. Defaults to returning the latest version of the Abor definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto the Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. If not provided will return all the entitled properties for that Abor. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Abor</returns>
        public async System.Threading.Tasks.Task<Abor> GetAborAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<Abor> localVarResponse = await GetAborWithHttpInfoAsync(scope, code, effectiveAt, asAt, propertyKeys, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetAbor: Get Abor. Retrieve the definition of a particular Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Abor properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Abor definition. Defaults to returning the latest version of the Abor definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto the Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. If not provided will return all the entitled properties for that Abor. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Abor)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<Abor>> GetAborWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->GetAbor");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->GetAbor");


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
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Abor>("/api/abor/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetAbor", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [DEPRECATED] GetJELines: DEPRECATED: please use GetJournalEntryLines instead. Get the JELines for the given Abor. DEPRECATED: please use GetJournalEntryLines instead. Gets the JELines for the given Abor                The JE Lines have been generated from transactions and translated via posting rules
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="jELinesQueryParameters">The query parameters used in running the generation of the JELines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve JELines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing JELines from a previous call to GetJELines. (optional)</param>
        /// <returns>VersionedResourceListOfJournalEntryLine</returns>
        public VersionedResourceListOfJournalEntryLine GetJELines(string scope, string code, JELinesQueryParameters jELinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), int? limit = default(int?), string page = default(string))
        {
            Lusid.Sdk.Client.ApiResponse<VersionedResourceListOfJournalEntryLine> localVarResponse = GetJELinesWithHttpInfo(scope, code, jELinesQueryParameters, asAt, limit, page);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [DEPRECATED] GetJELines: DEPRECATED: please use GetJournalEntryLines instead. Get the JELines for the given Abor. DEPRECATED: please use GetJournalEntryLines instead. Gets the JELines for the given Abor                The JE Lines have been generated from transactions and translated via posting rules
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="jELinesQueryParameters">The query parameters used in running the generation of the JELines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve JELines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing JELines from a previous call to GetJELines. (optional)</param>
        /// <returns>ApiResponse of VersionedResourceListOfJournalEntryLine</returns>
        public Lusid.Sdk.Client.ApiResponse<VersionedResourceListOfJournalEntryLine> GetJELinesWithHttpInfo(string scope, string code, JELinesQueryParameters jELinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), int? limit = default(int?), string page = default(string))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->GetJELines");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->GetJELines");

            // verify the required parameter 'jELinesQueryParameters' is set
            if (jELinesQueryParameters == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'jELinesQueryParameters' when calling AborApi->GetJELines");

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
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            localVarRequestOptions.Data = jELinesQueryParameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request
            var localVarResponse = this.Client.Post<VersionedResourceListOfJournalEntryLine>("/api/abor/{scope}/{code}/JELines/$query/$deprecated", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJELines", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [DEPRECATED] GetJELines: DEPRECATED: please use GetJournalEntryLines instead. Get the JELines for the given Abor. DEPRECATED: please use GetJournalEntryLines instead. Gets the JELines for the given Abor                The JE Lines have been generated from transactions and translated via posting rules
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="jELinesQueryParameters">The query parameters used in running the generation of the JELines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve JELines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing JELines from a previous call to GetJELines. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VersionedResourceListOfJournalEntryLine</returns>
        public async System.Threading.Tasks.Task<VersionedResourceListOfJournalEntryLine> GetJELinesAsync(string scope, string code, JELinesQueryParameters jELinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), int? limit = default(int?), string page = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<VersionedResourceListOfJournalEntryLine> localVarResponse = await GetJELinesWithHttpInfoAsync(scope, code, jELinesQueryParameters, asAt, limit, page, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [DEPRECATED] GetJELines: DEPRECATED: please use GetJournalEntryLines instead. Get the JELines for the given Abor. DEPRECATED: please use GetJournalEntryLines instead. Gets the JELines for the given Abor                The JE Lines have been generated from transactions and translated via posting rules
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="jELinesQueryParameters">The query parameters used in running the generation of the JELines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve JELines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing JELines from a previous call to GetJELines. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VersionedResourceListOfJournalEntryLine)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<VersionedResourceListOfJournalEntryLine>> GetJELinesWithHttpInfoAsync(string scope, string code, JELinesQueryParameters jELinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), int? limit = default(int?), string page = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->GetJELines");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->GetJELines");

            // verify the required parameter 'jELinesQueryParameters' is set
            if (jELinesQueryParameters == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'jELinesQueryParameters' when calling AborApi->GetJELines");


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
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            localVarRequestOptions.Data = jELinesQueryParameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<VersionedResourceListOfJournalEntryLine>("/api/abor/{scope}/{code}/JELines/$query/$deprecated", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJELines", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetJournalEntryLines: Get the Journal Entry lines for the given Abor. Gets the Journal Entry lines for the given Abor                The Journal Entry lines have been generated from transactions and translated via posting rules
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="journalEntryLinesQueryParameters">The query parameters used in running the generation of the Journal Entry lines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve Journal Entry lines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Journal Entry lines from a previous call to GetJournalEntryLines. (optional)</param>
        /// <returns>VersionedResourceListOfJournalEntryLine</returns>
        public VersionedResourceListOfJournalEntryLine GetJournalEntryLines(string scope, string code, JournalEntryLinesQueryParameters journalEntryLinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string))
        {
            Lusid.Sdk.Client.ApiResponse<VersionedResourceListOfJournalEntryLine> localVarResponse = GetJournalEntryLinesWithHttpInfo(scope, code, journalEntryLinesQueryParameters, asAt, filter, limit, page);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetJournalEntryLines: Get the Journal Entry lines for the given Abor. Gets the Journal Entry lines for the given Abor                The Journal Entry lines have been generated from transactions and translated via posting rules
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="journalEntryLinesQueryParameters">The query parameters used in running the generation of the Journal Entry lines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve Journal Entry lines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Journal Entry lines from a previous call to GetJournalEntryLines. (optional)</param>
        /// <returns>ApiResponse of VersionedResourceListOfJournalEntryLine</returns>
        public Lusid.Sdk.Client.ApiResponse<VersionedResourceListOfJournalEntryLine> GetJournalEntryLinesWithHttpInfo(string scope, string code, JournalEntryLinesQueryParameters journalEntryLinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->GetJournalEntryLines");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->GetJournalEntryLines");

            // verify the required parameter 'journalEntryLinesQueryParameters' is set
            if (journalEntryLinesQueryParameters == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'journalEntryLinesQueryParameters' when calling AborApi->GetJournalEntryLines");

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
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            localVarRequestOptions.Data = journalEntryLinesQueryParameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request
            var localVarResponse = this.Client.Post<VersionedResourceListOfJournalEntryLine>("/api/abor/{scope}/{code}/journalentrylines/$query", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJournalEntryLines", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetJournalEntryLines: Get the Journal Entry lines for the given Abor. Gets the Journal Entry lines for the given Abor                The Journal Entry lines have been generated from transactions and translated via posting rules
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="journalEntryLinesQueryParameters">The query parameters used in running the generation of the Journal Entry lines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve Journal Entry lines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Journal Entry lines from a previous call to GetJournalEntryLines. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VersionedResourceListOfJournalEntryLine</returns>
        public async System.Threading.Tasks.Task<VersionedResourceListOfJournalEntryLine> GetJournalEntryLinesAsync(string scope, string code, JournalEntryLinesQueryParameters journalEntryLinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<VersionedResourceListOfJournalEntryLine> localVarResponse = await GetJournalEntryLinesWithHttpInfoAsync(scope, code, journalEntryLinesQueryParameters, asAt, filter, limit, page, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetJournalEntryLines: Get the Journal Entry lines for the given Abor. Gets the Journal Entry lines for the given Abor                The Journal Entry lines have been generated from transactions and translated via posting rules
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is creating the unique identifier for the given Abor.</param>
        /// <param name="journalEntryLinesQueryParameters">The query parameters used in running the generation of the Journal Entry lines.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve Journal Entry lines. Defaults to returning the latest version               of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Journal Entry lines from a previous call to GetJournalEntryLines. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VersionedResourceListOfJournalEntryLine)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<VersionedResourceListOfJournalEntryLine>> GetJournalEntryLinesWithHttpInfoAsync(string scope, string code, JournalEntryLinesQueryParameters journalEntryLinesQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->GetJournalEntryLines");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->GetJournalEntryLines");

            // verify the required parameter 'journalEntryLinesQueryParameters' is set
            if (journalEntryLinesQueryParameters == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'journalEntryLinesQueryParameters' when calling AborApi->GetJournalEntryLines");


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
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            localVarRequestOptions.Data = journalEntryLinesQueryParameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<VersionedResourceListOfJournalEntryLine>("/api/abor/{scope}/{code}/journalentrylines/$query", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetJournalEntryLines", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetTrialBalance: Get the Trial balance for the given Abor. Gets the Trial balance for the given Abor    The Trial balance has been generated from transactions, translated via posting rules and aggregated based on a General Ledger Profile (where specified)
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is the unique identifier for the given Abor.</param>
        /// <param name="trialBalanceQueryParameters">The query parameters used in running the generation of the Trial Balance.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve trial balance. Defaults to returning the latest version              of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Trial balance from a previous call to Trial balance. (optional)</param>
        /// <returns>VersionedResourceListOfTrialBalance</returns>
        public VersionedResourceListOfTrialBalance GetTrialBalance(string scope, string code, TrialBalanceQueryParameters trialBalanceQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string))
        {
            Lusid.Sdk.Client.ApiResponse<VersionedResourceListOfTrialBalance> localVarResponse = GetTrialBalanceWithHttpInfo(scope, code, trialBalanceQueryParameters, asAt, filter, limit, page);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetTrialBalance: Get the Trial balance for the given Abor. Gets the Trial balance for the given Abor    The Trial balance has been generated from transactions, translated via posting rules and aggregated based on a General Ledger Profile (where specified)
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is the unique identifier for the given Abor.</param>
        /// <param name="trialBalanceQueryParameters">The query parameters used in running the generation of the Trial Balance.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve trial balance. Defaults to returning the latest version              of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Trial balance from a previous call to Trial balance. (optional)</param>
        /// <returns>ApiResponse of VersionedResourceListOfTrialBalance</returns>
        public Lusid.Sdk.Client.ApiResponse<VersionedResourceListOfTrialBalance> GetTrialBalanceWithHttpInfo(string scope, string code, TrialBalanceQueryParameters trialBalanceQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->GetTrialBalance");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->GetTrialBalance");

            // verify the required parameter 'trialBalanceQueryParameters' is set
            if (trialBalanceQueryParameters == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'trialBalanceQueryParameters' when calling AborApi->GetTrialBalance");

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
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            localVarRequestOptions.Data = trialBalanceQueryParameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request
            var localVarResponse = this.Client.Post<VersionedResourceListOfTrialBalance>("/api/abor/{scope}/{code}/trialbalance/$query", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialBalance", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetTrialBalance: Get the Trial balance for the given Abor. Gets the Trial balance for the given Abor    The Trial balance has been generated from transactions, translated via posting rules and aggregated based on a General Ledger Profile (where specified)
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is the unique identifier for the given Abor.</param>
        /// <param name="trialBalanceQueryParameters">The query parameters used in running the generation of the Trial Balance.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve trial balance. Defaults to returning the latest version              of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Trial balance from a previous call to Trial balance. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of VersionedResourceListOfTrialBalance</returns>
        public async System.Threading.Tasks.Task<VersionedResourceListOfTrialBalance> GetTrialBalanceAsync(string scope, string code, TrialBalanceQueryParameters trialBalanceQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<VersionedResourceListOfTrialBalance> localVarResponse = await GetTrialBalanceWithHttpInfoAsync(scope, code, trialBalanceQueryParameters, asAt, filter, limit, page, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetTrialBalance: Get the Trial balance for the given Abor. Gets the Trial balance for the given Abor    The Trial balance has been generated from transactions, translated via posting rules and aggregated based on a General Ledger Profile (where specified)
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor. Together with the scope is the unique identifier for the given Abor.</param>
        /// <param name="trialBalanceQueryParameters">The query parameters used in running the generation of the Trial Balance.</param>
        /// <param name="asAt">The asAt datetime at which to retrieve trial balance. Defaults to returning the latest version              of each transaction if not specified. (optional)</param>
        /// <param name="filter">\&quot;Expression to filter the result set.\&quot; (optional)</param>
        /// <param name="limit">When paginating, limit the number of returned results to this many. Defaults to 100 if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Trial balance from a previous call to Trial balance. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (VersionedResourceListOfTrialBalance)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<VersionedResourceListOfTrialBalance>> GetTrialBalanceWithHttpInfoAsync(string scope, string code, TrialBalanceQueryParameters trialBalanceQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), string filter = default(string), int? limit = default(int?), string page = default(string), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->GetTrialBalance");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->GetTrialBalance");

            // verify the required parameter 'trialBalanceQueryParameters' is set
            if (trialBalanceQueryParameters == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'trialBalanceQueryParameters' when calling AborApi->GetTrialBalance");


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
            if (asAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "asAt", asAt));
            }
            if (filter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "filter", filter));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            localVarRequestOptions.Data = trialBalanceQueryParameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<VersionedResourceListOfTrialBalance>("/api/abor/{scope}/{code}/trialbalance/$query", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetTrialBalance", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListAbors: List Abors. List all the Abors matching particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Abor. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Abor. Defaults to returning the latest version of each Abor if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Abor; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Abor type, specify \&quot;id.Code eq &#39;Abor1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto each Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. (optional)</param>
        /// <returns>PagedResourceListOfAbor</returns>
        public PagedResourceListOfAbor ListAbors(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfAbor> localVarResponse = ListAborsWithHttpInfo(effectiveAt, asAt, page, limit, filter, propertyKeys);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListAbors: List Abors. List all the Abors matching particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Abor. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Abor. Defaults to returning the latest version of each Abor if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Abor; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Abor type, specify \&quot;id.Code eq &#39;Abor1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto each Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfAbor</returns>
        public Lusid.Sdk.Client.ApiResponse<PagedResourceListOfAbor> ListAborsWithHttpInfo(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>))
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

            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request
            var localVarResponse = this.Client.Get<PagedResourceListOfAbor>("/api/abor", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListAbors", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListAbors: List Abors. List all the Abors matching particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Abor. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Abor. Defaults to returning the latest version of each Abor if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Abor; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Abor type, specify \&quot;id.Code eq &#39;Abor1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto each Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfAbor</returns>
        public async System.Threading.Tasks.Task<PagedResourceListOfAbor> ListAborsAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfAbor> localVarResponse = await ListAborsWithHttpInfoAsync(effectiveAt, asAt, page, limit, filter, propertyKeys, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListAbors: List Abors. List all the Abors matching particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Abor. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Abor. Defaults to returning the latest version of each Abor if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Abor; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Abor type, specify \&quot;id.Code eq &#39;Abor1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Abor&#39; domain to decorate onto each Abor.              These must take the format {domain}/{scope}/{code}, for example &#39;Abor/Manager/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfAbor)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<PagedResourceListOfAbor>> ListAborsWithHttpInfoAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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

            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<PagedResourceListOfAbor>("/api/abor", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListAbors", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListDiaryEntries: List diary entries. List all the diary entries matching particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Diary Entries. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the DiaryEntry. Defaults to returning the latest version of each DiaryEntry if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing diary entries; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the DiaryEntry type, specify \&quot;type eq &#39;PeriodBoundary&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;DiaryEntry&#39; domain to decorate onto each DiaryEntry.              These must take the format {domain}/{scope}/{code}, for example &#39;DiaryEntry/Report/Id&#39;. (optional)</param>
        /// <returns>PagedResourceListOfDiaryEntry</returns>
        public PagedResourceListOfDiaryEntry ListDiaryEntries(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfDiaryEntry> localVarResponse = ListDiaryEntriesWithHttpInfo(scope, code, effectiveAt, asAt, page, limit, filter, propertyKeys);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListDiaryEntries: List diary entries. List all the diary entries matching particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Diary Entries. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the DiaryEntry. Defaults to returning the latest version of each DiaryEntry if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing diary entries; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the DiaryEntry type, specify \&quot;type eq &#39;PeriodBoundary&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;DiaryEntry&#39; domain to decorate onto each DiaryEntry.              These must take the format {domain}/{scope}/{code}, for example &#39;DiaryEntry/Report/Id&#39;. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfDiaryEntry</returns>
        public Lusid.Sdk.Client.ApiResponse<PagedResourceListOfDiaryEntry> ListDiaryEntriesWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->ListDiaryEntries");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->ListDiaryEntries");

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
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request
            var localVarResponse = this.Client.Get<PagedResourceListOfDiaryEntry>("/api/abor/{scope}/{code}/accountingdiary", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListDiaryEntries", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListDiaryEntries: List diary entries. List all the diary entries matching particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Diary Entries. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the DiaryEntry. Defaults to returning the latest version of each DiaryEntry if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing diary entries; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the DiaryEntry type, specify \&quot;type eq &#39;PeriodBoundary&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;DiaryEntry&#39; domain to decorate onto each DiaryEntry.              These must take the format {domain}/{scope}/{code}, for example &#39;DiaryEntry/Report/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfDiaryEntry</returns>
        public async System.Threading.Tasks.Task<PagedResourceListOfDiaryEntry> ListDiaryEntriesAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfDiaryEntry> localVarResponse = await ListDiaryEntriesWithHttpInfoAsync(scope, code, effectiveAt, asAt, page, limit, filter, propertyKeys, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListDiaryEntries: List diary entries. List all the diary entries matching particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Diary Entries. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the DiaryEntry. Defaults to returning the latest version of each DiaryEntry if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing diary entries; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the DiaryEntry type, specify \&quot;type eq &#39;PeriodBoundary&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;DiaryEntry&#39; domain to decorate onto each DiaryEntry.              These must take the format {domain}/{scope}/{code}, for example &#39;DiaryEntry/Report/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfDiaryEntry)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<PagedResourceListOfDiaryEntry>> ListDiaryEntriesWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->ListDiaryEntries");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->ListDiaryEntries");


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
            if (effectiveAt != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("", "effectiveAt", effectiveAt));
            }
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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<PagedResourceListOfDiaryEntry>("/api/abor/{scope}/{code}/accountingdiary", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListDiaryEntries", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] LockPeriod: Locks the last Closed or given Closed Period. Locks the specified or last locked period for the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="lockPeriodDiaryEntryRequest">The request body, detailing lock details (optional)</param>
        /// <returns>DiaryEntry</returns>
        public DiaryEntry LockPeriod(string scope, string code, LockPeriodDiaryEntryRequest lockPeriodDiaryEntryRequest = default(LockPeriodDiaryEntryRequest))
        {
            Lusid.Sdk.Client.ApiResponse<DiaryEntry> localVarResponse = LockPeriodWithHttpInfo(scope, code, lockPeriodDiaryEntryRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] LockPeriod: Locks the last Closed or given Closed Period. Locks the specified or last locked period for the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="lockPeriodDiaryEntryRequest">The request body, detailing lock details (optional)</param>
        /// <returns>ApiResponse of DiaryEntry</returns>
        public Lusid.Sdk.Client.ApiResponse<DiaryEntry> LockPeriodWithHttpInfo(string scope, string code, LockPeriodDiaryEntryRequest lockPeriodDiaryEntryRequest = default(LockPeriodDiaryEntryRequest))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->LockPeriod");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->LockPeriod");

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
            localVarRequestOptions.Data = lockPeriodDiaryEntryRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request
            var localVarResponse = this.Client.Post<DiaryEntry>("/api/abor/{scope}/{code}/accountingdiary/$lockperiod", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("LockPeriod", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] LockPeriod: Locks the last Closed or given Closed Period. Locks the specified or last locked period for the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="lockPeriodDiaryEntryRequest">The request body, detailing lock details (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DiaryEntry</returns>
        public async System.Threading.Tasks.Task<DiaryEntry> LockPeriodAsync(string scope, string code, LockPeriodDiaryEntryRequest lockPeriodDiaryEntryRequest = default(LockPeriodDiaryEntryRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DiaryEntry> localVarResponse = await LockPeriodWithHttpInfoAsync(scope, code, lockPeriodDiaryEntryRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] LockPeriod: Locks the last Closed or given Closed Period. Locks the specified or last locked period for the given Abor.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor.</param>
        /// <param name="code">The code of the Abor.</param>
        /// <param name="lockPeriodDiaryEntryRequest">The request body, detailing lock details (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DiaryEntry)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DiaryEntry>> LockPeriodWithHttpInfoAsync(string scope, string code, LockPeriodDiaryEntryRequest lockPeriodDiaryEntryRequest = default(LockPeriodDiaryEntryRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->LockPeriod");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->LockPeriod");


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
            localVarRequestOptions.Data = lockPeriodDiaryEntryRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<DiaryEntry>("/api/abor/{scope}/{code}/accountingdiary/$lockperiod", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("LockPeriod", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ReOpenPeriods: Reopen periods from a seed Diary Entry Code or when not specified, the last Closed Period for the given Abor. Reopens one or more periods.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="reOpenPeriodDiaryEntryRequest">The request body, detailing re open details (optional)</param>
        /// <returns>PeriodDiaryEntriesReopenedResponse</returns>
        public PeriodDiaryEntriesReopenedResponse ReOpenPeriods(string scope, string code, ReOpenPeriodDiaryEntryRequest reOpenPeriodDiaryEntryRequest = default(ReOpenPeriodDiaryEntryRequest))
        {
            Lusid.Sdk.Client.ApiResponse<PeriodDiaryEntriesReopenedResponse> localVarResponse = ReOpenPeriodsWithHttpInfo(scope, code, reOpenPeriodDiaryEntryRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ReOpenPeriods: Reopen periods from a seed Diary Entry Code or when not specified, the last Closed Period for the given Abor. Reopens one or more periods.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="reOpenPeriodDiaryEntryRequest">The request body, detailing re open details (optional)</param>
        /// <returns>ApiResponse of PeriodDiaryEntriesReopenedResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<PeriodDiaryEntriesReopenedResponse> ReOpenPeriodsWithHttpInfo(string scope, string code, ReOpenPeriodDiaryEntryRequest reOpenPeriodDiaryEntryRequest = default(ReOpenPeriodDiaryEntryRequest))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->ReOpenPeriods");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->ReOpenPeriods");

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
            localVarRequestOptions.Data = reOpenPeriodDiaryEntryRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request
            var localVarResponse = this.Client.Post<PeriodDiaryEntriesReopenedResponse>("/api/abor/{scope}/{code}/accountingdiary/$reopenperiods", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReOpenPeriods", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ReOpenPeriods: Reopen periods from a seed Diary Entry Code or when not specified, the last Closed Period for the given Abor. Reopens one or more periods.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="reOpenPeriodDiaryEntryRequest">The request body, detailing re open details (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PeriodDiaryEntriesReopenedResponse</returns>
        public async System.Threading.Tasks.Task<PeriodDiaryEntriesReopenedResponse> ReOpenPeriodsAsync(string scope, string code, ReOpenPeriodDiaryEntryRequest reOpenPeriodDiaryEntryRequest = default(ReOpenPeriodDiaryEntryRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<PeriodDiaryEntriesReopenedResponse> localVarResponse = await ReOpenPeriodsWithHttpInfoAsync(scope, code, reOpenPeriodDiaryEntryRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ReOpenPeriods: Reopen periods from a seed Diary Entry Code or when not specified, the last Closed Period for the given Abor. Reopens one or more periods.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to be deleted.</param>
        /// <param name="code">The code of the Abor to be deleted. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="reOpenPeriodDiaryEntryRequest">The request body, detailing re open details (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PeriodDiaryEntriesReopenedResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<PeriodDiaryEntriesReopenedResponse>> ReOpenPeriodsWithHttpInfoAsync(string scope, string code, ReOpenPeriodDiaryEntryRequest reOpenPeriodDiaryEntryRequest = default(ReOpenPeriodDiaryEntryRequest), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->ReOpenPeriods");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->ReOpenPeriods");


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
            localVarRequestOptions.Data = reOpenPeriodDiaryEntryRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<PeriodDiaryEntriesReopenedResponse>("/api/abor/{scope}/{code}/accountingdiary/$reopenperiods", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ReOpenPeriods", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertAborProperties: Upsert Abor properties Update or insert one or more properties onto a single Abor. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Abor&#39;.                Upserting a property that exists for an Abor, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to update or insert the properties onto.</param>
        /// <param name="code">The code of the Abor to update or insert the properties onto. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Abor. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Abor/Manager/Id\&quot;. (optional)</param>
        /// <returns>AborProperties</returns>
        public AborProperties UpsertAborProperties(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>))
        {
            Lusid.Sdk.Client.ApiResponse<AborProperties> localVarResponse = UpsertAborPropertiesWithHttpInfo(scope, code, requestBody);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertAborProperties: Upsert Abor properties Update or insert one or more properties onto a single Abor. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Abor&#39;.                Upserting a property that exists for an Abor, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to update or insert the properties onto.</param>
        /// <param name="code">The code of the Abor to update or insert the properties onto. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Abor. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Abor/Manager/Id\&quot;. (optional)</param>
        /// <returns>ApiResponse of AborProperties</returns>
        public Lusid.Sdk.Client.ApiResponse<AborProperties> UpsertAborPropertiesWithHttpInfo(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->UpsertAborProperties");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->UpsertAborProperties");

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
            localVarRequestOptions.Data = requestBody;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request
            var localVarResponse = this.Client.Post<AborProperties>("/api/abor/{scope}/{code}/properties/$upsert", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertAborProperties", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertAborProperties: Upsert Abor properties Update or insert one or more properties onto a single Abor. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Abor&#39;.                Upserting a property that exists for an Abor, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to update or insert the properties onto.</param>
        /// <param name="code">The code of the Abor to update or insert the properties onto. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Abor. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Abor/Manager/Id\&quot;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of AborProperties</returns>
        public async System.Threading.Tasks.Task<AborProperties> UpsertAborPropertiesAsync(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<AborProperties> localVarResponse = await UpsertAborPropertiesWithHttpInfoAsync(scope, code, requestBody, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertAborProperties: Upsert Abor properties Update or insert one or more properties onto a single Abor. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Abor&#39;.                Upserting a property that exists for an Abor, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Abor to update or insert the properties onto.</param>
        /// <param name="code">The code of the Abor to update or insert the properties onto. Together with the scope this uniquely identifies the Abor.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Abor. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Abor/Manager/Id\&quot;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (AborProperties)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<AborProperties>> UpsertAborPropertiesWithHttpInfoAsync(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling AborApi->UpsertAborProperties");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling AborApi->UpsertAborProperties");


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
            localVarRequestOptions.Data = requestBody;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.201");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<AborProperties>("/api/abor/{scope}/{code}/properties/$upsert", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertAborProperties", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}