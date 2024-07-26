/*
 * LUSID API
 *
 * # Introduction  This page documents the [LUSID APIs](../../../api/swagger), which allows authorised clients to query and update their data within the LUSID platform.  SDKs to interact with the LUSID APIs are available in the following languages and frameworks:  * [C#](https://github.com/finbourne/lusid-sdk-csharp) * [Java](https://github.com/finbourne/lusid-sdk-java) * [JavaScript](https://github.com/finbourne/lusid-sdk-js) * [Python](https://github.com/finbourne/lusid-sdk-python) * [Angular](https://github.com/finbourne/lusid-sdk-angular)  The LUSID platform is made up of a number of sub-applications. You can find the API / swagger documentation by following the links in the table below.   | Application   | Description                                                                       | API / Swagger Documentation                          | |- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | LUSID         | Open, API-first, developer-friendly investment data platform.                     | [Swagger](../../../api/swagger/index.html)           | | Web app       | User-facing front end for LUSID.                                                  | [Swagger](../../../app/swagger/index.html)           | | Scheduler     | Automated job scheduler.                                                          | [Swagger](../../../scheduler2/swagger/index.html)    | | Insights      | Monitoring and troubleshooting service.                                           | [Swagger](../../../insights/swagger/index.html)      | | Identity      | Identity management for LUSID (in conjunction with Access)                        | [Swagger](../../../identity/swagger/index.html)      | | Access        | Access control for LUSID (in conjunction with Identity)                           | [Swagger](../../../access/swagger/index.html)        | | Drive         | Secure file repository and manager for collaboration.                             | [Swagger](../../../drive/swagger/index.html)         | | Luminesce     | Data virtualisation service (query data from multiple providers, including LUSID) | [Swagger](../../../honeycomb/swagger/index.html)     | | Notification  | Notification service.                                                             | [Swagger](../../../notification/swagger/index.html)  | | Configuration | File store for secrets and other sensitive information.                           | [Swagger](../../../configuration/swagger/index.html) | | Workflow      | Workflow service.                                                                 | [Swagger](../../../workflow/swagger/index.html)      |   # Error Codes  | Code|Name|Description | | - --|- --|- -- | | <a name=\"-10\">-10</a>|Server Configuration Error|  | | <a name=\"-1\">-1</a>|Unknown error|An unexpected error was encountered on our side. | | <a name=\"102\">102</a>|Version Not Found|  | | <a name=\"103\">103</a>|Api Rate Limit Violation|  | | <a name=\"104\">104</a>|Instrument Not Found|  | | <a name=\"105\">105</a>|Property Not Found|  | | <a name=\"106\">106</a>|Portfolio Recursion Depth|  | | <a name=\"108\">108</a>|Group Not Found|  | | <a name=\"109\">109</a>|Portfolio Not Found|  | | <a name=\"110\">110</a>|Property Schema Not Found|  | | <a name=\"111\">111</a>|Portfolio Ancestry Not Found|  | | <a name=\"112\">112</a>|Portfolio With Id Already Exists|  | | <a name=\"113\">113</a>|Orphaned Portfolio|  | | <a name=\"119\">119</a>|Missing Base Claims|  | | <a name=\"121\">121</a>|Property Not Defined|  | | <a name=\"122\">122</a>|Cannot Delete System Property|  | | <a name=\"123\">123</a>|Cannot Modify Immutable Property Field|  | | <a name=\"124\">124</a>|Property Already Exists|  | | <a name=\"125\">125</a>|Invalid Property Life Time|  | | <a name=\"126\">126</a>|Property Constraint Style Excludes Properties|  | | <a name=\"127\">127</a>|Cannot Modify Default Data Type|  | | <a name=\"128\">128</a>|Group Already Exists|  | | <a name=\"129\">129</a>|No Such Data Type|  | | <a name=\"130\">130</a>|Undefined Value For Data Type|  | | <a name=\"131\">131</a>|Unsupported Value Type Defined On Data Type|  | | <a name=\"132\">132</a>|Validation Error|  | | <a name=\"133\">133</a>|Loop Detected In Group Hierarchy|  | | <a name=\"134\">134</a>|Undefined Acceptable Values|  | | <a name=\"135\">135</a>|Sub Group Already Exists|  | | <a name=\"138\">138</a>|Price Source Not Found|  | | <a name=\"139\">139</a>|Analytic Store Not Found|  | | <a name=\"141\">141</a>|Analytic Store Already Exists|  | | <a name=\"143\">143</a>|Client Instrument Already Exists|  | | <a name=\"144\">144</a>|Duplicate In Parameter Set|  | | <a name=\"147\">147</a>|Results Not Found|  | | <a name=\"148\">148</a>|Order Field Not In Result Set|  | | <a name=\"149\">149</a>|Operation Failed|  | | <a name=\"150\">150</a>|Elastic Search Error|  | | <a name=\"151\">151</a>|Invalid Parameter Value|  | | <a name=\"153\">153</a>|Command Processing Failure|  | | <a name=\"154\">154</a>|Entity State Construction Failure|  | | <a name=\"155\">155</a>|Entity Timeline Does Not Exist|  | | <a name=\"156\">156</a>|Concurrency Conflict Failure|  | | <a name=\"157\">157</a>|Invalid Request|  | | <a name=\"158\">158</a>|Event Publish Unknown|  | | <a name=\"159\">159</a>|Event Query Failure|  | | <a name=\"160\">160</a>|Blob Did Not Exist|  | | <a name=\"162\">162</a>|Sub System Request Failure|  | | <a name=\"163\">163</a>|Sub System Configuration Failure|  | | <a name=\"165\">165</a>|Failed To Delete|  | | <a name=\"166\">166</a>|Upsert Client Instrument Failure|  | | <a name=\"167\">167</a>|Illegal As At Interval|  | | <a name=\"168\">168</a>|Illegal Bitemporal Query|  | | <a name=\"169\">169</a>|Invalid Alternate Id|  | | <a name=\"170\">170</a>|Cannot Add Non-Writable Properties To Entity|  | | <a name=\"171\">171</a>|Entity Already Exists In Group|  | | <a name=\"172\">172</a>|Entity With Id Does Not Exist|  | | <a name=\"173\">173</a>|Entity With Id Already Exists|  | | <a name=\"174\">174</a>|Derived Portfolio Details Do Not Exist|  | | <a name=\"175\">175</a>|Entity Not In Group|  | | <a name=\"176\">176</a>|Portfolio With Name Already Exists|  | | <a name=\"177\">177</a>|Invalid Transactions|  | | <a name=\"178\">178</a>|Reference Portfolio Not Found|  | | <a name=\"179\">179</a>|Duplicate Id|  | | <a name=\"180\">180</a>|Command Retrieval Failure|  | | <a name=\"181\">181</a>|Data Filter Application Failure|  | | <a name=\"182\">182</a>|Search Failed|  | | <a name=\"183\">183</a>|Movements Engine Configuration Key Failure|  | | <a name=\"184\">184</a>|Fx Rate Source Not Found|  | | <a name=\"185\">185</a>|Accrual Source Not Found|  | | <a name=\"186\">186</a>|Access Denied|  | | <a name=\"187\">187</a>|Invalid Identity Token|  | | <a name=\"188\">188</a>|Invalid Request Headers|  | | <a name=\"189\">189</a>|Price Not Found|  | | <a name=\"190\">190</a>|Invalid Sub Holding Keys Provided|  | | <a name=\"191\">191</a>|Duplicate Sub Holding Keys Provided|  | | <a name=\"192\">192</a>|Cut Definition Not Found|  | | <a name=\"193\">193</a>|Cut Definition Invalid|  | | <a name=\"194\">194</a>|Time Variant Property Deletion Date Unspecified|  | | <a name=\"195\">195</a>|Perpetual Property Deletion Date Specified|  | | <a name=\"196\">196</a>|Time Variant Property Upsert Date Unspecified|  | | <a name=\"197\">197</a>|Perpetual Property Upsert Date Specified|  | | <a name=\"200\">200</a>|Invalid Unit For Data Type|  | | <a name=\"201\">201</a>|Invalid Type For Data Type|  | | <a name=\"202\">202</a>|Invalid Value For Data Type|  | | <a name=\"203\">203</a>|Unit Not Defined For Data Type|  | | <a name=\"204\">204</a>|Units Not Supported On Data Type|  | | <a name=\"205\">205</a>|Cannot Specify Units On Data Type|  | | <a name=\"206\">206</a>|Unit Schema Inconsistent With Data Type|  | | <a name=\"207\">207</a>|Unit Definition Not Specified|  | | <a name=\"208\">208</a>|Duplicate Unit Definitions Specified|  | | <a name=\"209\">209</a>|Invalid Units Definition|  | | <a name=\"210\">210</a>|Invalid Instrument Identifier Unit|  | | <a name=\"211\">211</a>|Holdings Adjustment Does Not Exist|  | | <a name=\"212\">212</a>|Could Not Build Excel Url|  | | <a name=\"213\">213</a>|Could Not Get Excel Version|  | | <a name=\"214\">214</a>|Instrument By Code Not Found|  | | <a name=\"215\">215</a>|Entity Schema Does Not Exist|  | | <a name=\"216\">216</a>|Feature Not Supported On Portfolio Type|  | | <a name=\"217\">217</a>|Quote Not Found|  | | <a name=\"218\">218</a>|Invalid Quote Identifier|  | | <a name=\"219\">219</a>|Invalid Metric For Data Type|  | | <a name=\"220\">220</a>|Invalid Instrument Definition|  | | <a name=\"221\">221</a>|Instrument Upsert Failure|  | | <a name=\"222\">222</a>|Reference Portfolio Request Not Supported|  | | <a name=\"223\">223</a>|Transaction Portfolio Request Not Supported|  | | <a name=\"224\">224</a>|Invalid Property Value Assignment|  | | <a name=\"230\">230</a>|Transaction Type Not Found|  | | <a name=\"231\">231</a>|Transaction Type Duplication|  | | <a name=\"232\">232</a>|Portfolio Does Not Exist At Given Date|  | | <a name=\"233\">233</a>|Query Parser Failure|  | | <a name=\"234\">234</a>|Duplicate Constituent|  | | <a name=\"235\">235</a>|Unresolved Instrument Constituent|  | | <a name=\"236\">236</a>|Unresolved Instrument In Transition|  | | <a name=\"237\">237</a>|Missing Side Definitions|  | | <a name=\"240\">240</a>|Duplicate Calculations Failure|  | | <a name=\"299\">299</a>|Invalid Recipe|  | | <a name=\"300\">300</a>|Missing Recipe|  | | <a name=\"301\">301</a>|Dependencies|  | | <a name=\"304\">304</a>|Portfolio Preprocess Failure|  | | <a name=\"310\">310</a>|Valuation Engine Failure|  | | <a name=\"311\">311</a>|Task Factory Failure|  | | <a name=\"312\">312</a>|Task Evaluation Failure|  | | <a name=\"313\">313</a>|Task Generation Failure|  | | <a name=\"314\">314</a>|Engine Configuration Failure|  | | <a name=\"315\">315</a>|Model Specification Failure|  | | <a name=\"320\">320</a>|Market Data Key Failure|  | | <a name=\"321\">321</a>|Market Resolver Failure|  | | <a name=\"322\">322</a>|Market Data Failure|  | | <a name=\"330\">330</a>|Curve Failure|  | | <a name=\"331\">331</a>|Volatility Surface Failure|  | | <a name=\"332\">332</a>|Volatility Cube Failure|  | | <a name=\"350\">350</a>|Instrument Failure|  | | <a name=\"351\">351</a>|Cash Flows Failure|  | | <a name=\"352\">352</a>|Reference Data Failure|  | | <a name=\"360\">360</a>|Aggregation Failure|  | | <a name=\"361\">361</a>|Aggregation Measure Failure|  | | <a name=\"370\">370</a>|Result Retrieval Failure|  | | <a name=\"371\">371</a>|Result Processing Failure|  | | <a name=\"372\">372</a>|Vendor Result Processing Failure|  | | <a name=\"373\">373</a>|Vendor Result Mapping Failure|  | | <a name=\"374\">374</a>|Vendor Library Unauthorised|  | | <a name=\"375\">375</a>|Vendor Connectivity Error|  | | <a name=\"376\">376</a>|Vendor Interface Error|  | | <a name=\"377\">377</a>|Vendor Pricing Failure|  | | <a name=\"378\">378</a>|Vendor Translation Failure|  | | <a name=\"379\">379</a>|Vendor Key Mapping Failure|  | | <a name=\"380\">380</a>|Vendor Reflection Failure|  | | <a name=\"381\">381</a>|Vendor Process Failure|  | | <a name=\"382\">382</a>|Vendor System Failure|  | | <a name=\"390\">390</a>|Attempt To Upsert Duplicate Quotes|  | | <a name=\"391\">391</a>|Corporate Action Source Does Not Exist|  | | <a name=\"392\">392</a>|Corporate Action Source Already Exists|  | | <a name=\"393\">393</a>|Instrument Identifier Already In Use|  | | <a name=\"394\">394</a>|Properties Not Found|  | | <a name=\"395\">395</a>|Batch Operation Aborted|  | | <a name=\"400\">400</a>|Invalid Iso4217 Currency Code|  | | <a name=\"401\">401</a>|Cannot Assign Instrument Identifier To Currency|  | | <a name=\"402\">402</a>|Cannot Assign Currency Identifier To Non Currency|  | | <a name=\"403\">403</a>|Currency Instrument Cannot Be Deleted|  | | <a name=\"404\">404</a>|Currency Instrument Cannot Have Economic Definition|  | | <a name=\"405\">405</a>|Currency Instrument Cannot Have Lookthrough Portfolio|  | | <a name=\"406\">406</a>|Cannot Create Currency Instrument With Multiple Identifiers|  | | <a name=\"407\">407</a>|Specified Currency Is Undefined|  | | <a name=\"410\">410</a>|Index Does Not Exist|  | | <a name=\"411\">411</a>|Sort Field Does Not Exist|  | | <a name=\"413\">413</a>|Negative Pagination Parameters|  | | <a name=\"414\">414</a>|Invalid Search Syntax|  | | <a name=\"415\">415</a>|Filter Execution Timeout|  | | <a name=\"420\">420</a>|Side Definition Inconsistent|  | | <a name=\"450\">450</a>|Invalid Quote Access Metadata Rule|  | | <a name=\"451\">451</a>|Access Metadata Not Found|  | | <a name=\"452\">452</a>|Invalid Access Metadata Identifier|  | | <a name=\"460\">460</a>|Standard Resource Not Found|  | | <a name=\"461\">461</a>|Standard Resource Conflict|  | | <a name=\"462\">462</a>|Calendar Not Found|  | | <a name=\"463\">463</a>|Date In A Calendar Not Found|  | | <a name=\"464\">464</a>|Invalid Date Source Data|  | | <a name=\"465\">465</a>|Invalid Timezone|  | | <a name=\"601\">601</a>|Person Identifier Already In Use|  | | <a name=\"602\">602</a>|Person Not Found|  | | <a name=\"603\">603</a>|Cannot Set Identifier|  | | <a name=\"617\">617</a>|Invalid Recipe Specification In Request|  | | <a name=\"618\">618</a>|Inline Recipe Deserialisation Failure|  | | <a name=\"619\">619</a>|Identifier Types Not Set For Entity|  | | <a name=\"620\">620</a>|Cannot Delete All Client Defined Identifiers|  | | <a name=\"650\">650</a>|The Order requested was not found.|  | | <a name=\"654\">654</a>|The Allocation requested was not found.|  | | <a name=\"655\">655</a>|Cannot build the fx forward target with the given holdings.|  | | <a name=\"656\">656</a>|Group does not contain expected entities.|  | | <a name=\"665\">665</a>|Destination directory not found|  | | <a name=\"667\">667</a>|Relation definition already exists|  | | <a name=\"672\">672</a>|Could not retrieve file contents|  | | <a name=\"673\">673</a>|Missing entitlements for entities in Group|  | | <a name=\"674\">674</a>|Next Best Action not found|  | | <a name=\"676\">676</a>|Relation definition not defined|  | | <a name=\"677\">677</a>|Invalid entity identifier for relation|  | | <a name=\"681\">681</a>|Sorting by specified field not supported|One or more of the provided fields to order by were either invalid or not supported. | | <a name=\"682\">682</a>|Too many fields to sort by|The number of fields to sort the data by exceeds the number allowed by the endpoint | | <a name=\"684\">684</a>|Sequence Not Found|  | | <a name=\"685\">685</a>|Sequence Already Exists|  | | <a name=\"686\">686</a>|Non-cycling sequence has been exhausted|  | | <a name=\"687\">687</a>|Legal Entity Identifier Already In Use|  | | <a name=\"688\">688</a>|Legal Entity Not Found|  | | <a name=\"689\">689</a>|The supplied pagination token is invalid|  | | <a name=\"690\">690</a>|Property Type Is Not Supported|  | | <a name=\"691\">691</a>|Multiple Tax-lots For Currency Type Is Not Supported|  | | <a name=\"692\">692</a>|This endpoint does not support impersonation|  | | <a name=\"693\">693</a>|Entity type is not supported for Relationship|  | | <a name=\"694\">694</a>|Relationship Validation Failure|  | | <a name=\"695\">695</a>|Relationship Not Found|  | | <a name=\"697\">697</a>|Derived Property Formula No Longer Valid|  | | <a name=\"698\">698</a>|Story is not available|  | | <a name=\"703\">703</a>|Corporate Action Does Not Exist|  | | <a name=\"720\">720</a>|The provided sort and filter combination is not valid|  | | <a name=\"721\">721</a>|A2B generation failed|  | | <a name=\"722\">722</a>|Aggregated Return Calculation Failure|  | | <a name=\"723\">723</a>|Custom Entity Definition Identifier Already In Use|  | | <a name=\"724\">724</a>|Custom Entity Definition Not Found|  | | <a name=\"725\">725</a>|The Placement requested was not found.|  | | <a name=\"726\">726</a>|The Execution requested was not found.|  | | <a name=\"727\">727</a>|The Block requested was not found.|  | | <a name=\"728\">728</a>|The Participation requested was not found.|  | | <a name=\"729\">729</a>|The Package requested was not found.|  | | <a name=\"730\">730</a>|The OrderInstruction requested was not found.|  | | <a name=\"732\">732</a>|Custom Entity not found.|  | | <a name=\"733\">733</a>|Custom Entity Identifier already in use.|  | | <a name=\"735\">735</a>|Calculation Failed.|  | | <a name=\"736\">736</a>|An expected key on HttpResponse is missing.|  | | <a name=\"737\">737</a>|A required fee detail is missing.|  | | <a name=\"738\">738</a>|Zero rows were returned from Luminesce|  | | <a name=\"739\">739</a>|Provided Weekend Mask was invalid|  | | <a name=\"742\">742</a>|Custom Entity fields do not match the definition|  | | <a name=\"746\">746</a>|The provided sequence is not valid.|  | | <a name=\"751\">751</a>|The type of the Custom Entity is different than the type provided in the definition.|  | | <a name=\"752\">752</a>|Luminesce process returned an error.|  | | <a name=\"753\">753</a>|File name or content incompatible with operation.|  | | <a name=\"755\">755</a>|Schema of response from Drive is not as expected.|  | | <a name=\"757\">757</a>|Schema of response from Luminesce is not as expected.|  | | <a name=\"758\">758</a>|Luminesce timed out.|  | | <a name=\"763\">763</a>|Invalid Lusid Entity Identifier Unit|  | | <a name=\"768\">768</a>|Fee rule not found.|  | | <a name=\"769\">769</a>|Cannot update the base currency of a portfolio with transactions loaded|  | | <a name=\"771\">771</a>|Transaction configuration source not found|  | | <a name=\"774\">774</a>|Compliance rule not found.|  | | <a name=\"775\">775</a>|Fund accounting document cannot be processed.|  | | <a name=\"778\">778</a>|Unable to look up FX rate from trade ccy to portfolio ccy for some of the trades.|  | | <a name=\"782\">782</a>|The Property definition dataType is not matching the derivation formula dataType|  | | <a name=\"783\">783</a>|The Property definition domain is not supported for derived properties|  | | <a name=\"788\">788</a>|Compliance run not found failure.|  | | <a name=\"790\">790</a>|Custom Entity has missing or invalid identifiers|  | | <a name=\"791\">791</a>|Custom Entity definition already exists|  | | <a name=\"792\">792</a>|Compliance PropertyKey is missing.|  | | <a name=\"793\">793</a>|Compliance Criteria Value for matching is missing.|  | | <a name=\"795\">795</a>|Cannot delete identifier definition|  | | <a name=\"796\">796</a>|Tax rule set not found.|  | | <a name=\"797\">797</a>|A tax rule set with this id already exists.|  | | <a name=\"798\">798</a>|Multiple rule sets for the same property key are applicable.|  | | <a name=\"799\">799</a>|The request must contain a date or diary entry.|  | | <a name=\"800\">800</a>|Can not upsert an instrument event of this type.|  | | <a name=\"801\">801</a>|The instrument event does not exist.|  | | <a name=\"802\">802</a>|The Instrument event is missing salient information.|  | | <a name=\"803\">803</a>|The Instrument event could not be processed.|  | | <a name=\"804\">804</a>|Some data requested does not follow the order graph assumptions.|  | | <a name=\"805\">805</a>|The instrument event type does not exist.|  | | <a name=\"806\">806</a>|The transaction template specification does not exist.|  | | <a name=\"807\">807</a>|The default transaction template does not exist.|  | | <a name=\"808\">808</a>|The transaction template does not exist.|  | | <a name=\"811\">811</a>|A price could not be found for an order.|  | | <a name=\"812\">812</a>|A price could not be found for an allocation.|  | | <a name=\"813\">813</a>|Chart of Accounts not found.|  | | <a name=\"814\">814</a>|Account not found.|  | | <a name=\"815\">815</a>|Abor not found.|  | | <a name=\"816\">816</a>|Abor Configuration not found.|  | | <a name=\"817\">817</a>|Reconciliation mapping not found|  | | <a name=\"818\">818</a>|Attribute type could not be deleted because it doesn't exist.|  | | <a name=\"819\">819</a>|Reconciliation not found.|  | | <a name=\"820\">820</a>|Custodian Account not found.|  | | <a name=\"821\">821</a>|Allocation Failure|  | | <a name=\"822\">822</a>|Reconciliation run not found|  | | <a name=\"823\">823</a>|Reconciliation break not found|  | | <a name=\"824\">824</a>|Entity link type could not be deleted because it doesn't exist.|  | | <a name=\"828\">828</a>|Address key definition not found.|  | | <a name=\"829\">829</a>|Compliance template not found.|  | | <a name=\"830\">830</a>|Action not supported|  | | <a name=\"831\">831</a>|Reference list not found.|  | | <a name=\"832\">832</a>|Posting Module not found.|  | | <a name=\"833\">833</a>|The type of parameter provided did not match that required by the compliance rule.|  | | <a name=\"834\">834</a>|The parameters provided by a rule did not match those required by its template.|  | | <a name=\"835\">835</a>|The entity has a property in a domain that is not supprted for that entity type.|  | | <a name=\"836\">836</a>|Structured result data not found.|  | | <a name=\"837\">837</a>|Diary entry not found.|  | | <a name=\"838\">838</a>|Diary entry could not be created.|  | | <a name=\"839\">839</a>|Diary entry already exists.|  | | <a name=\"861\">861</a>|Compliance run summary not found.|  | | <a name=\"869\">869</a>|Conflicting instrument properties in batch.|  | | <a name=\"870\">870</a>|Compliance run summary already exists.|  | | <a name=\"871\">871</a>|The specified impersonated user does not exist|  | | <a name=\"874\">874</a>|Provided Property Domain is not supported for entity filter.|  | | <a name=\"875\">875</a>|Cannot Delete System Reference List.|  | | <a name=\"876\">876</a>|Cleardown Module not found.|  | | <a name=\"879\">879</a>|Portfolios do not have the same base currency|  | | <a name=\"880\">880</a>|There was a problem with the definition of the compliance expression.|  | | <a name=\"881\">881</a>|Block overplaced.|  | | <a name=\"882\">882</a>|Order not approved.|  | | <a name=\"883\">883</a>|Cannot update the shared fields of a block with associated orders.|  | | <a name=\"886\">886</a>|Cannot lock the period.|  | | <a name=\"887\">887</a>|Cannot apply clear down module.|  | | <a name=\"888\">888</a>|Cannot upsert Instrument Event Instruction.|  | | <a name=\"889\">889</a>|Cannot read Instrument Event Instruction.|  | | <a name=\"910\">910</a>|Cannot update a block referenced by a placement.|  | | <a name=\"911\">911</a>|A Fund that references this Abor already exists.|  | | <a name=\"912\">912</a>|Cannot add decision to Staged Modification.|  | | <a name=\"913\">913</a>|The Staged Modification could not be applied.|  | | <a name=\"914\">914</a>|Action cannot be executed.|  | | <a name=\"915\">915</a>|Cannot upsert multiple versions of the same property in one request.|  | | <a name=\"916\">916</a>|Placement and direct descendents have more executed quantity than total placement quantity.|  | | <a name=\"917\">917</a>|Cannot update a placement with this EntryType.|  | | <a name=\"918\">918</a>|Cannot update a placement in this State.|  | | <a name=\"919\">919</a>|Placement could not be cancelled.|  | 
 *
 * The version of the OpenAPI document: 1.1.381
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
    public interface IFundsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// [EXPERIMENTAL] AcceptEstimateValuationPoint: Accepts an Estimate Valuation Point.
        /// </summary>
        /// <remarks>
        /// Accepts the specified estimate Valuation Point. Should the Valuation Point differ since the valuation Point was last run, status will be marked as &#39;Candidate&#39;, otherwise it will be marked as &#39;Final&#39;
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the Diary Entry code for the Estimate Valuation Point to move to Candidate or Final state.</param>
        /// <returns>ValuationPointDataResponse</returns>
        ValuationPointDataResponse AcceptEstimateValuationPoint(string scope, string code, ValuationPointDataRequest valuationPointDataRequest);

        /// <summary>
        /// [EXPERIMENTAL] AcceptEstimateValuationPoint: Accepts an Estimate Valuation Point.
        /// </summary>
        /// <remarks>
        /// Accepts the specified estimate Valuation Point. Should the Valuation Point differ since the valuation Point was last run, status will be marked as &#39;Candidate&#39;, otherwise it will be marked as &#39;Final&#39;
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the Diary Entry code for the Estimate Valuation Point to move to Candidate or Final state.</param>
        /// <returns>ApiResponse of ValuationPointDataResponse</returns>
        ApiResponse<ValuationPointDataResponse> AcceptEstimateValuationPointWithHttpInfo(string scope, string code, ValuationPointDataRequest valuationPointDataRequest);
        /// <summary>
        /// [EXPERIMENTAL] CreateFee: Create a Fee.
        /// </summary>
        /// <remarks>
        /// Create the given Fee.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeRequest">The Fee to create.</param>
        /// <returns>Fee</returns>
        Fee CreateFee(string scope, string code, FeeRequest feeRequest);

        /// <summary>
        /// [EXPERIMENTAL] CreateFee: Create a Fee.
        /// </summary>
        /// <remarks>
        /// Create the given Fee.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeRequest">The Fee to create.</param>
        /// <returns>ApiResponse of Fee</returns>
        ApiResponse<Fee> CreateFeeWithHttpInfo(string scope, string code, FeeRequest feeRequest);
        /// <summary>
        /// [EXPERIMENTAL] CreateFund: Create a Fund.
        /// </summary>
        /// <remarks>
        /// Create the given Fund.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="fundRequest">The definition of the Fund.</param>
        /// <returns>Fund</returns>
        Fund CreateFund(string scope, FundRequest fundRequest);

        /// <summary>
        /// [EXPERIMENTAL] CreateFund: Create a Fund.
        /// </summary>
        /// <remarks>
        /// Create the given Fund.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="fundRequest">The definition of the Fund.</param>
        /// <returns>ApiResponse of Fund</returns>
        ApiResponse<Fund> CreateFundWithHttpInfo(string scope, FundRequest fundRequest);
        /// <summary>
        /// [EXPERIMENTAL] DeleteFee: Delete a Fee.
        /// </summary>
        /// <remarks>
        /// Delete the given Fee.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to be deleted.</param>
        /// <returns>DeletedEntityResponse</returns>
        DeletedEntityResponse DeleteFee(string scope, string code, string feeCode);

        /// <summary>
        /// [EXPERIMENTAL] DeleteFee: Delete a Fee.
        /// </summary>
        /// <remarks>
        /// Delete the given Fee.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to be deleted.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        ApiResponse<DeletedEntityResponse> DeleteFeeWithHttpInfo(string scope, string code, string feeCode);
        /// <summary>
        /// [EXPERIMENTAL] DeleteFund: Delete a Fund.
        /// </summary>
        /// <remarks>
        /// Delete the given Fund.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to be deleted.</param>
        /// <param name="code">The code of the Fund to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <returns>DeletedEntityResponse</returns>
        DeletedEntityResponse DeleteFund(string scope, string code);

        /// <summary>
        /// [EXPERIMENTAL] DeleteFund: Delete a Fund.
        /// </summary>
        /// <remarks>
        /// Delete the given Fund.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to be deleted.</param>
        /// <param name="code">The code of the Fund to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        ApiResponse<DeletedEntityResponse> DeleteFundWithHttpInfo(string scope, string code);
        /// <summary>
        /// [EXPERIMENTAL] DeleteValuationPoint: Delete a Valuation Point.
        /// </summary>
        /// <remarks>
        /// Deletes the given Valuation Point.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund for the valuation point to be deleted.</param>
        /// <param name="code">The code of the Fund containing the Valuation Point to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="diaryEntryCode">The diary entry code for the valuation Point to be deleted.</param>
        /// <returns>DeletedEntityResponse</returns>
        DeletedEntityResponse DeleteValuationPoint(string scope, string code, string diaryEntryCode);

        /// <summary>
        /// [EXPERIMENTAL] DeleteValuationPoint: Delete a Valuation Point.
        /// </summary>
        /// <remarks>
        /// Deletes the given Valuation Point.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund for the valuation point to be deleted.</param>
        /// <param name="code">The code of the Fund containing the Valuation Point to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="diaryEntryCode">The diary entry code for the valuation Point to be deleted.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        ApiResponse<DeletedEntityResponse> DeleteValuationPointWithHttpInfo(string scope, string code, string diaryEntryCode);
        /// <summary>
        /// [EXPERIMENTAL] FinaliseCandidateValuationPoint: Finalise Candidate.
        /// </summary>
        /// <remarks>
        /// Moves a &#39;Candidate&#39; status Valuation Point to status &#39;Final&#39;.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the diary entry code to mark as final.</param>
        /// <returns>ValuationPointDataResponse</returns>
        ValuationPointDataResponse FinaliseCandidateValuationPoint(string scope, string code, ValuationPointDataRequest valuationPointDataRequest);

        /// <summary>
        /// [EXPERIMENTAL] FinaliseCandidateValuationPoint: Finalise Candidate.
        /// </summary>
        /// <remarks>
        /// Moves a &#39;Candidate&#39; status Valuation Point to status &#39;Final&#39;.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the diary entry code to mark as final.</param>
        /// <returns>ApiResponse of ValuationPointDataResponse</returns>
        ApiResponse<ValuationPointDataResponse> FinaliseCandidateValuationPointWithHttpInfo(string scope, string code, ValuationPointDataRequest valuationPointDataRequest);
        /// <summary>
        /// [EXPERIMENTAL] GetFee: Get a Fee for a specified Fund.
        /// </summary>
        /// <remarks>
        /// Retrieve a fee for a specified Fund
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fee properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fee. Defaults to returning the latest version of the Fee if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto the Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <returns>Fee</returns>
        Fee GetFee(string scope, string code, string feeCode, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>));

        /// <summary>
        /// [EXPERIMENTAL] GetFee: Get a Fee for a specified Fund.
        /// </summary>
        /// <remarks>
        /// Retrieve a fee for a specified Fund
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fee properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fee. Defaults to returning the latest version of the Fee if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto the Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <returns>ApiResponse of Fee</returns>
        ApiResponse<Fee> GetFeeWithHttpInfo(string scope, string code, string feeCode, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>));
        /// <summary>
        /// [EXPERIMENTAL] GetFund: Get a Fund.
        /// </summary>
        /// <remarks>
        /// Retrieve the definition of a particular Fund.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fund properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto the Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <returns>Fund</returns>
        Fund GetFund(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>));

        /// <summary>
        /// [EXPERIMENTAL] GetFund: Get a Fund.
        /// </summary>
        /// <remarks>
        /// Retrieve the definition of a particular Fund.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fund properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto the Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <returns>ApiResponse of Fund</returns>
        ApiResponse<Fund> GetFundWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>));
        /// <summary>
        /// [EXPERIMENTAL] GetValuationPointData: Get Valuation Point Data for a Fund.
        /// </summary>
        /// <remarks>
        /// Retrieves the Valuation Point data for a date or specified Diary Entry Id.  The endpoint will internally extract all &#39;Assets&#39; and &#39;Liabilities&#39; from the related ABOR&#39;s Trial balance to produce a GAV.  Start date will be assumed from the last &#39;official&#39; DiaryEntry and EndDate will be as provided.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataQueryParameters">The arguments to use for querying the Valuation Point data</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <returns>ValuationPointDataResponse</returns>
        ValuationPointDataResponse GetValuationPointData(string scope, string code, ValuationPointDataQueryParameters valuationPointDataQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?));

        /// <summary>
        /// [EXPERIMENTAL] GetValuationPointData: Get Valuation Point Data for a Fund.
        /// </summary>
        /// <remarks>
        /// Retrieves the Valuation Point data for a date or specified Diary Entry Id.  The endpoint will internally extract all &#39;Assets&#39; and &#39;Liabilities&#39; from the related ABOR&#39;s Trial balance to produce a GAV.  Start date will be assumed from the last &#39;official&#39; DiaryEntry and EndDate will be as provided.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataQueryParameters">The arguments to use for querying the Valuation Point data</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <returns>ApiResponse of ValuationPointDataResponse</returns>
        ApiResponse<ValuationPointDataResponse> GetValuationPointDataWithHttpInfo(string scope, string code, ValuationPointDataQueryParameters valuationPointDataQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?));
        /// <summary>
        /// [EXPERIMENTAL] ListFees: List Fees for a specified Fund.
        /// </summary>
        /// <remarks>
        /// List all the Fees matching a particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Fees. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Fees. Defaults to returning the latest version of each Fee if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing fees; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the treatment, specify \&quot;treatment eq &#39;Monthly&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto each Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. (optional)</param>
        /// <returns>PagedResourceListOfFee</returns>
        PagedResourceListOfFee ListFees(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>));

        /// <summary>
        /// [EXPERIMENTAL] ListFees: List Fees for a specified Fund.
        /// </summary>
        /// <remarks>
        /// List all the Fees matching a particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Fees. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Fees. Defaults to returning the latest version of each Fee if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing fees; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the treatment, specify \&quot;treatment eq &#39;Monthly&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto each Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfFee</returns>
        ApiResponse<PagedResourceListOfFee> ListFeesWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>));
        /// <summary>
        /// [EXPERIMENTAL] ListFunds: List Funds.
        /// </summary>
        /// <remarks>
        /// List all the Funds matching particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Funds. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Funds. Defaults to returning the latest version of each Fund if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Funds; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Fund type, specify \&quot;id.Code eq &#39;Fund1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto each Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. (optional)</param>
        /// <returns>PagedResourceListOfFund</returns>
        PagedResourceListOfFund ListFunds(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>));

        /// <summary>
        /// [EXPERIMENTAL] ListFunds: List Funds.
        /// </summary>
        /// <remarks>
        /// List all the Funds matching particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Funds. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Funds. Defaults to returning the latest version of each Fund if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Funds; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Fund type, specify \&quot;id.Code eq &#39;Fund1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto each Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfFund</returns>
        ApiResponse<PagedResourceListOfFund> ListFundsWithHttpInfo(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>));
        /// <summary>
        /// [EXPERIMENTAL] PatchFee: Patch Fee.
        /// </summary>
        /// <remarks>
        /// Create or update certain fields for a particular Fee.  The behaviour is defined by the JSON Patch specification.                Currently supported fields are: EndDate.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="operation">The json patch document. For more information see: https://datatracker.ietf.org/doc/html/rfc6902.</param>
        /// <returns>Fee</returns>
        Fee PatchFee(string scope, string code, string feeCode, List<Operation> operation);

        /// <summary>
        /// [EXPERIMENTAL] PatchFee: Patch Fee.
        /// </summary>
        /// <remarks>
        /// Create or update certain fields for a particular Fee.  The behaviour is defined by the JSON Patch specification.                Currently supported fields are: EndDate.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="operation">The json patch document. For more information see: https://datatracker.ietf.org/doc/html/rfc6902.</param>
        /// <returns>ApiResponse of Fee</returns>
        ApiResponse<Fee> PatchFeeWithHttpInfo(string scope, string code, string feeCode, List<Operation> operation);
        /// <summary>
        /// [EXPERIMENTAL] SetShareClassInstruments: Set the ShareClass Instruments on a fund.
        /// </summary>
        /// <remarks>
        /// Update the ShareClass Instruments on an existing fund with the set of instruments provided.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="setShareClassInstrumentsRequest">The scopes and instrument identifiers for the instruments to be set.</param>
        /// <returns>Fund</returns>
        Fund SetShareClassInstruments(string scope, string code, SetShareClassInstrumentsRequest setShareClassInstrumentsRequest);

        /// <summary>
        /// [EXPERIMENTAL] SetShareClassInstruments: Set the ShareClass Instruments on a fund.
        /// </summary>
        /// <remarks>
        /// Update the ShareClass Instruments on an existing fund with the set of instruments provided.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="setShareClassInstrumentsRequest">The scopes and instrument identifiers for the instruments to be set.</param>
        /// <returns>ApiResponse of Fund</returns>
        ApiResponse<Fund> SetShareClassInstrumentsWithHttpInfo(string scope, string code, SetShareClassInstrumentsRequest setShareClassInstrumentsRequest);
        /// <summary>
        /// [EXPERIMENTAL] UpsertDiaryEntryTypeValuationPoint: Upsert Valuation Point.
        /// </summary>
        /// <remarks>
        /// Update or insert the estimate Valuation Point.                If the Valuation Point does not exist, this method will create it in estimate state.                If the Valuation Point already exists and is in estimate state, the Valuation Point will be updated with the newly specified information in this request.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="upsertValuationPointRequest">The Valuation Point Estimate definition to Upsert</param>
        /// <returns>DiaryEntry</returns>
        DiaryEntry UpsertDiaryEntryTypeValuationPoint(string scope, string code, UpsertValuationPointRequest upsertValuationPointRequest);

        /// <summary>
        /// [EXPERIMENTAL] UpsertDiaryEntryTypeValuationPoint: Upsert Valuation Point.
        /// </summary>
        /// <remarks>
        /// Update or insert the estimate Valuation Point.                If the Valuation Point does not exist, this method will create it in estimate state.                If the Valuation Point already exists and is in estimate state, the Valuation Point will be updated with the newly specified information in this request.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="upsertValuationPointRequest">The Valuation Point Estimate definition to Upsert</param>
        /// <returns>ApiResponse of DiaryEntry</returns>
        ApiResponse<DiaryEntry> UpsertDiaryEntryTypeValuationPointWithHttpInfo(string scope, string code, UpsertValuationPointRequest upsertValuationPointRequest);
        /// <summary>
        /// [EXPERIMENTAL] UpsertFeeProperties: Upsert Fee properties.
        /// </summary>
        /// <remarks>
        /// Update or insert one or more properties onto a single Fee. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fee&#39;.                Upserting a property that exists for an Fee, with a null value, will delete the instance of the property for that group.       Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to update or insert the properties onto.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fee. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fee/Manager/Id\&quot;. (optional)</param>
        /// <returns>FeeProperties</returns>
        FeeProperties UpsertFeeProperties(string scope, string code, string feeCode, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>));

        /// <summary>
        /// [EXPERIMENTAL] UpsertFeeProperties: Upsert Fee properties.
        /// </summary>
        /// <remarks>
        /// Update or insert one or more properties onto a single Fee. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fee&#39;.                Upserting a property that exists for an Fee, with a null value, will delete the instance of the property for that group.       Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to update or insert the properties onto.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fee. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fee/Manager/Id\&quot;. (optional)</param>
        /// <returns>ApiResponse of FeeProperties</returns>
        ApiResponse<FeeProperties> UpsertFeePropertiesWithHttpInfo(string scope, string code, string feeCode, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>));
        /// <summary>
        /// [EXPERIMENTAL] UpsertFundProperties: Upsert Fund properties.
        /// </summary>
        /// <remarks>
        /// Update or insert one or more properties onto a single Fund. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fund&#39;.                Upserting a property that exists for an Fund, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to update or insert the properties onto.</param>
        /// <param name="code">The code of the Fund to update or insert the properties onto. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fund. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fund/Manager/Id\&quot;. (optional)</param>
        /// <returns>FundProperties</returns>
        FundProperties UpsertFundProperties(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>));

        /// <summary>
        /// [EXPERIMENTAL] UpsertFundProperties: Upsert Fund properties.
        /// </summary>
        /// <remarks>
        /// Update or insert one or more properties onto a single Fund. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fund&#39;.                Upserting a property that exists for an Fund, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to update or insert the properties onto.</param>
        /// <param name="code">The code of the Fund to update or insert the properties onto. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fund. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fund/Manager/Id\&quot;. (optional)</param>
        /// <returns>ApiResponse of FundProperties</returns>
        ApiResponse<FundProperties> UpsertFundPropertiesWithHttpInfo(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>));
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFundsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// [EXPERIMENTAL] AcceptEstimateValuationPoint: Accepts an Estimate Valuation Point.
        /// </summary>
        /// <remarks>
        /// Accepts the specified estimate Valuation Point. Should the Valuation Point differ since the valuation Point was last run, status will be marked as &#39;Candidate&#39;, otherwise it will be marked as &#39;Final&#39;
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the Diary Entry code for the Estimate Valuation Point to move to Candidate or Final state.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ValuationPointDataResponse</returns>
        System.Threading.Tasks.Task<ValuationPointDataResponse> AcceptEstimateValuationPointAsync(string scope, string code, ValuationPointDataRequest valuationPointDataRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] AcceptEstimateValuationPoint: Accepts an Estimate Valuation Point.
        /// </summary>
        /// <remarks>
        /// Accepts the specified estimate Valuation Point. Should the Valuation Point differ since the valuation Point was last run, status will be marked as &#39;Candidate&#39;, otherwise it will be marked as &#39;Final&#39;
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the Diary Entry code for the Estimate Valuation Point to move to Candidate or Final state.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ValuationPointDataResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ValuationPointDataResponse>> AcceptEstimateValuationPointWithHttpInfoAsync(string scope, string code, ValuationPointDataRequest valuationPointDataRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] CreateFee: Create a Fee.
        /// </summary>
        /// <remarks>
        /// Create the given Fee.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeRequest">The Fee to create.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Fee</returns>
        System.Threading.Tasks.Task<Fee> CreateFeeAsync(string scope, string code, FeeRequest feeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] CreateFee: Create a Fee.
        /// </summary>
        /// <remarks>
        /// Create the given Fee.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeRequest">The Fee to create.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Fee)</returns>
        System.Threading.Tasks.Task<ApiResponse<Fee>> CreateFeeWithHttpInfoAsync(string scope, string code, FeeRequest feeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] CreateFund: Create a Fund.
        /// </summary>
        /// <remarks>
        /// Create the given Fund.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="fundRequest">The definition of the Fund.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Fund</returns>
        System.Threading.Tasks.Task<Fund> CreateFundAsync(string scope, FundRequest fundRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] CreateFund: Create a Fund.
        /// </summary>
        /// <remarks>
        /// Create the given Fund.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="fundRequest">The definition of the Fund.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Fund)</returns>
        System.Threading.Tasks.Task<ApiResponse<Fund>> CreateFundWithHttpInfoAsync(string scope, FundRequest fundRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] DeleteFee: Delete a Fee.
        /// </summary>
        /// <remarks>
        /// Delete the given Fee.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to be deleted.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        System.Threading.Tasks.Task<DeletedEntityResponse> DeleteFeeAsync(string scope, string code, string feeCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] DeleteFee: Delete a Fee.
        /// </summary>
        /// <remarks>
        /// Delete the given Fee.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to be deleted.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeletedEntityResponse>> DeleteFeeWithHttpInfoAsync(string scope, string code, string feeCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] DeleteFund: Delete a Fund.
        /// </summary>
        /// <remarks>
        /// Delete the given Fund.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to be deleted.</param>
        /// <param name="code">The code of the Fund to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        System.Threading.Tasks.Task<DeletedEntityResponse> DeleteFundAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] DeleteFund: Delete a Fund.
        /// </summary>
        /// <remarks>
        /// Delete the given Fund.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to be deleted.</param>
        /// <param name="code">The code of the Fund to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeletedEntityResponse>> DeleteFundWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] DeleteValuationPoint: Delete a Valuation Point.
        /// </summary>
        /// <remarks>
        /// Deletes the given Valuation Point.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund for the valuation point to be deleted.</param>
        /// <param name="code">The code of the Fund containing the Valuation Point to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="diaryEntryCode">The diary entry code for the valuation Point to be deleted.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        System.Threading.Tasks.Task<DeletedEntityResponse> DeleteValuationPointAsync(string scope, string code, string diaryEntryCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] DeleteValuationPoint: Delete a Valuation Point.
        /// </summary>
        /// <remarks>
        /// Deletes the given Valuation Point.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund for the valuation point to be deleted.</param>
        /// <param name="code">The code of the Fund containing the Valuation Point to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="diaryEntryCode">The diary entry code for the valuation Point to be deleted.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<DeletedEntityResponse>> DeleteValuationPointWithHttpInfoAsync(string scope, string code, string diaryEntryCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] FinaliseCandidateValuationPoint: Finalise Candidate.
        /// </summary>
        /// <remarks>
        /// Moves a &#39;Candidate&#39; status Valuation Point to status &#39;Final&#39;.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the diary entry code to mark as final.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ValuationPointDataResponse</returns>
        System.Threading.Tasks.Task<ValuationPointDataResponse> FinaliseCandidateValuationPointAsync(string scope, string code, ValuationPointDataRequest valuationPointDataRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] FinaliseCandidateValuationPoint: Finalise Candidate.
        /// </summary>
        /// <remarks>
        /// Moves a &#39;Candidate&#39; status Valuation Point to status &#39;Final&#39;.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the diary entry code to mark as final.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ValuationPointDataResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ValuationPointDataResponse>> FinaliseCandidateValuationPointWithHttpInfoAsync(string scope, string code, ValuationPointDataRequest valuationPointDataRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] GetFee: Get a Fee for a specified Fund.
        /// </summary>
        /// <remarks>
        /// Retrieve a fee for a specified Fund
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fee properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fee. Defaults to returning the latest version of the Fee if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto the Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Fee</returns>
        System.Threading.Tasks.Task<Fee> GetFeeAsync(string scope, string code, string feeCode, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] GetFee: Get a Fee for a specified Fund.
        /// </summary>
        /// <remarks>
        /// Retrieve a fee for a specified Fund
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fee properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fee. Defaults to returning the latest version of the Fee if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto the Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Fee)</returns>
        System.Threading.Tasks.Task<ApiResponse<Fee>> GetFeeWithHttpInfoAsync(string scope, string code, string feeCode, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] GetFund: Get a Fund.
        /// </summary>
        /// <remarks>
        /// Retrieve the definition of a particular Fund.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fund properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto the Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Fund</returns>
        System.Threading.Tasks.Task<Fund> GetFundAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] GetFund: Get a Fund.
        /// </summary>
        /// <remarks>
        /// Retrieve the definition of a particular Fund.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fund properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto the Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Fund)</returns>
        System.Threading.Tasks.Task<ApiResponse<Fund>> GetFundWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] GetValuationPointData: Get Valuation Point Data for a Fund.
        /// </summary>
        /// <remarks>
        /// Retrieves the Valuation Point data for a date or specified Diary Entry Id.  The endpoint will internally extract all &#39;Assets&#39; and &#39;Liabilities&#39; from the related ABOR&#39;s Trial balance to produce a GAV.  Start date will be assumed from the last &#39;official&#39; DiaryEntry and EndDate will be as provided.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataQueryParameters">The arguments to use for querying the Valuation Point data</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ValuationPointDataResponse</returns>
        System.Threading.Tasks.Task<ValuationPointDataResponse> GetValuationPointDataAsync(string scope, string code, ValuationPointDataQueryParameters valuationPointDataQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] GetValuationPointData: Get Valuation Point Data for a Fund.
        /// </summary>
        /// <remarks>
        /// Retrieves the Valuation Point data for a date or specified Diary Entry Id.  The endpoint will internally extract all &#39;Assets&#39; and &#39;Liabilities&#39; from the related ABOR&#39;s Trial balance to produce a GAV.  Start date will be assumed from the last &#39;official&#39; DiaryEntry and EndDate will be as provided.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataQueryParameters">The arguments to use for querying the Valuation Point data</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ValuationPointDataResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<ValuationPointDataResponse>> GetValuationPointDataWithHttpInfoAsync(string scope, string code, ValuationPointDataQueryParameters valuationPointDataQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] ListFees: List Fees for a specified Fund.
        /// </summary>
        /// <remarks>
        /// List all the Fees matching a particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Fees. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Fees. Defaults to returning the latest version of each Fee if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing fees; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the treatment, specify \&quot;treatment eq &#39;Monthly&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto each Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfFee</returns>
        System.Threading.Tasks.Task<PagedResourceListOfFee> ListFeesAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] ListFees: List Fees for a specified Fund.
        /// </summary>
        /// <remarks>
        /// List all the Fees matching a particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Fees. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Fees. Defaults to returning the latest version of each Fee if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing fees; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the treatment, specify \&quot;treatment eq &#39;Monthly&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto each Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfFee)</returns>
        System.Threading.Tasks.Task<ApiResponse<PagedResourceListOfFee>> ListFeesWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] ListFunds: List Funds.
        /// </summary>
        /// <remarks>
        /// List all the Funds matching particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Funds. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Funds. Defaults to returning the latest version of each Fund if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Funds; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Fund type, specify \&quot;id.Code eq &#39;Fund1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto each Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfFund</returns>
        System.Threading.Tasks.Task<PagedResourceListOfFund> ListFundsAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] ListFunds: List Funds.
        /// </summary>
        /// <remarks>
        /// List all the Funds matching particular criteria.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Funds. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Funds. Defaults to returning the latest version of each Fund if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Funds; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Fund type, specify \&quot;id.Code eq &#39;Fund1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto each Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfFund)</returns>
        System.Threading.Tasks.Task<ApiResponse<PagedResourceListOfFund>> ListFundsWithHttpInfoAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] PatchFee: Patch Fee.
        /// </summary>
        /// <remarks>
        /// Create or update certain fields for a particular Fee.  The behaviour is defined by the JSON Patch specification.                Currently supported fields are: EndDate.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="operation">The json patch document. For more information see: https://datatracker.ietf.org/doc/html/rfc6902.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Fee</returns>
        System.Threading.Tasks.Task<Fee> PatchFeeAsync(string scope, string code, string feeCode, List<Operation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] PatchFee: Patch Fee.
        /// </summary>
        /// <remarks>
        /// Create or update certain fields for a particular Fee.  The behaviour is defined by the JSON Patch specification.                Currently supported fields are: EndDate.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="operation">The json patch document. For more information see: https://datatracker.ietf.org/doc/html/rfc6902.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Fee)</returns>
        System.Threading.Tasks.Task<ApiResponse<Fee>> PatchFeeWithHttpInfoAsync(string scope, string code, string feeCode, List<Operation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] SetShareClassInstruments: Set the ShareClass Instruments on a fund.
        /// </summary>
        /// <remarks>
        /// Update the ShareClass Instruments on an existing fund with the set of instruments provided.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="setShareClassInstrumentsRequest">The scopes and instrument identifiers for the instruments to be set.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Fund</returns>
        System.Threading.Tasks.Task<Fund> SetShareClassInstrumentsAsync(string scope, string code, SetShareClassInstrumentsRequest setShareClassInstrumentsRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] SetShareClassInstruments: Set the ShareClass Instruments on a fund.
        /// </summary>
        /// <remarks>
        /// Update the ShareClass Instruments on an existing fund with the set of instruments provided.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="setShareClassInstrumentsRequest">The scopes and instrument identifiers for the instruments to be set.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Fund)</returns>
        System.Threading.Tasks.Task<ApiResponse<Fund>> SetShareClassInstrumentsWithHttpInfoAsync(string scope, string code, SetShareClassInstrumentsRequest setShareClassInstrumentsRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] UpsertDiaryEntryTypeValuationPoint: Upsert Valuation Point.
        /// </summary>
        /// <remarks>
        /// Update or insert the estimate Valuation Point.                If the Valuation Point does not exist, this method will create it in estimate state.                If the Valuation Point already exists and is in estimate state, the Valuation Point will be updated with the newly specified information in this request.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="upsertValuationPointRequest">The Valuation Point Estimate definition to Upsert</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DiaryEntry</returns>
        System.Threading.Tasks.Task<DiaryEntry> UpsertDiaryEntryTypeValuationPointAsync(string scope, string code, UpsertValuationPointRequest upsertValuationPointRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] UpsertDiaryEntryTypeValuationPoint: Upsert Valuation Point.
        /// </summary>
        /// <remarks>
        /// Update or insert the estimate Valuation Point.                If the Valuation Point does not exist, this method will create it in estimate state.                If the Valuation Point already exists and is in estimate state, the Valuation Point will be updated with the newly specified information in this request.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="upsertValuationPointRequest">The Valuation Point Estimate definition to Upsert</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DiaryEntry)</returns>
        System.Threading.Tasks.Task<ApiResponse<DiaryEntry>> UpsertDiaryEntryTypeValuationPointWithHttpInfoAsync(string scope, string code, UpsertValuationPointRequest upsertValuationPointRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] UpsertFeeProperties: Upsert Fee properties.
        /// </summary>
        /// <remarks>
        /// Update or insert one or more properties onto a single Fee. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fee&#39;.                Upserting a property that exists for an Fee, with a null value, will delete the instance of the property for that group.       Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to update or insert the properties onto.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fee. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fee/Manager/Id\&quot;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FeeProperties</returns>
        System.Threading.Tasks.Task<FeeProperties> UpsertFeePropertiesAsync(string scope, string code, string feeCode, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] UpsertFeeProperties: Upsert Fee properties.
        /// </summary>
        /// <remarks>
        /// Update or insert one or more properties onto a single Fee. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fee&#39;.                Upserting a property that exists for an Fee, with a null value, will delete the instance of the property for that group.       Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to update or insert the properties onto.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fee. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fee/Manager/Id\&quot;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FeeProperties)</returns>
        System.Threading.Tasks.Task<ApiResponse<FeeProperties>> UpsertFeePropertiesWithHttpInfoAsync(string scope, string code, string feeCode, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// [EXPERIMENTAL] UpsertFundProperties: Upsert Fund properties.
        /// </summary>
        /// <remarks>
        /// Update or insert one or more properties onto a single Fund. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fund&#39;.                Upserting a property that exists for an Fund, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to update or insert the properties onto.</param>
        /// <param name="code">The code of the Fund to update or insert the properties onto. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fund. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fund/Manager/Id\&quot;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FundProperties</returns>
        System.Threading.Tasks.Task<FundProperties> UpsertFundPropertiesAsync(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// [EXPERIMENTAL] UpsertFundProperties: Upsert Fund properties.
        /// </summary>
        /// <remarks>
        /// Update or insert one or more properties onto a single Fund. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fund&#39;.                Upserting a property that exists for an Fund, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </remarks>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to update or insert the properties onto.</param>
        /// <param name="code">The code of the Fund to update or insert the properties onto. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fund. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fund/Manager/Id\&quot;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FundProperties)</returns>
        System.Threading.Tasks.Task<ApiResponse<FundProperties>> UpsertFundPropertiesWithHttpInfoAsync(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IFundsApi : IFundsApiSync, IFundsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class FundsApi : IFundsApi
    {
        private Lusid.Sdk.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="FundsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FundsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FundsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public FundsApi(String basePath)
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
        /// Initializes a new instance of the <see cref="FundsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public FundsApi(Lusid.Sdk.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = configuration;
            this.Client = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Lusid.Sdk.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Lusid.Sdk.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FundsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public FundsApi(Lusid.Sdk.Client.ISynchronousClient client, Lusid.Sdk.Client.IAsynchronousClient asyncClient, Lusid.Sdk.Client.IReadableConfiguration configuration)
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
        /// [EXPERIMENTAL] AcceptEstimateValuationPoint: Accepts an Estimate Valuation Point. Accepts the specified estimate Valuation Point. Should the Valuation Point differ since the valuation Point was last run, status will be marked as &#39;Candidate&#39;, otherwise it will be marked as &#39;Final&#39;
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the Diary Entry code for the Estimate Valuation Point to move to Candidate or Final state.</param>
        /// <returns>ValuationPointDataResponse</returns>
        public ValuationPointDataResponse AcceptEstimateValuationPoint(string scope, string code, ValuationPointDataRequest valuationPointDataRequest)
        {
            Lusid.Sdk.Client.ApiResponse<ValuationPointDataResponse> localVarResponse = AcceptEstimateValuationPointWithHttpInfo(scope, code, valuationPointDataRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] AcceptEstimateValuationPoint: Accepts an Estimate Valuation Point. Accepts the specified estimate Valuation Point. Should the Valuation Point differ since the valuation Point was last run, status will be marked as &#39;Candidate&#39;, otherwise it will be marked as &#39;Final&#39;
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the Diary Entry code for the Estimate Valuation Point to move to Candidate or Final state.</param>
        /// <returns>ApiResponse of ValuationPointDataResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<ValuationPointDataResponse> AcceptEstimateValuationPointWithHttpInfo(string scope, string code, ValuationPointDataRequest valuationPointDataRequest)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->AcceptEstimateValuationPoint");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->AcceptEstimateValuationPoint");

            // verify the required parameter 'valuationPointDataRequest' is set
            if (valuationPointDataRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'valuationPointDataRequest' when calling FundsApi->AcceptEstimateValuationPoint");

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
            localVarRequestOptions.Data = valuationPointDataRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ValuationPointDataResponse>("/api/funds/{scope}/{code}/valuationpoints/$acceptestimate", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AcceptEstimateValuationPoint", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] AcceptEstimateValuationPoint: Accepts an Estimate Valuation Point. Accepts the specified estimate Valuation Point. Should the Valuation Point differ since the valuation Point was last run, status will be marked as &#39;Candidate&#39;, otherwise it will be marked as &#39;Final&#39;
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the Diary Entry code for the Estimate Valuation Point to move to Candidate or Final state.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ValuationPointDataResponse</returns>
        public async System.Threading.Tasks.Task<ValuationPointDataResponse> AcceptEstimateValuationPointAsync(string scope, string code, ValuationPointDataRequest valuationPointDataRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ValuationPointDataResponse> localVarResponse = await AcceptEstimateValuationPointWithHttpInfoAsync(scope, code, valuationPointDataRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] AcceptEstimateValuationPoint: Accepts an Estimate Valuation Point. Accepts the specified estimate Valuation Point. Should the Valuation Point differ since the valuation Point was last run, status will be marked as &#39;Candidate&#39;, otherwise it will be marked as &#39;Final&#39;
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the Diary Entry code for the Estimate Valuation Point to move to Candidate or Final state.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ValuationPointDataResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ValuationPointDataResponse>> AcceptEstimateValuationPointWithHttpInfoAsync(string scope, string code, ValuationPointDataRequest valuationPointDataRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->AcceptEstimateValuationPoint");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->AcceptEstimateValuationPoint");

            // verify the required parameter 'valuationPointDataRequest' is set
            if (valuationPointDataRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'valuationPointDataRequest' when calling FundsApi->AcceptEstimateValuationPoint");


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
            localVarRequestOptions.Data = valuationPointDataRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ValuationPointDataResponse>("/api/funds/{scope}/{code}/valuationpoints/$acceptestimate", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("AcceptEstimateValuationPoint", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateFee: Create a Fee. Create the given Fee.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeRequest">The Fee to create.</param>
        /// <returns>Fee</returns>
        public Fee CreateFee(string scope, string code, FeeRequest feeRequest)
        {
            Lusid.Sdk.Client.ApiResponse<Fee> localVarResponse = CreateFeeWithHttpInfo(scope, code, feeRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateFee: Create a Fee. Create the given Fee.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeRequest">The Fee to create.</param>
        /// <returns>ApiResponse of Fee</returns>
        public Lusid.Sdk.Client.ApiResponse<Fee> CreateFeeWithHttpInfo(string scope, string code, FeeRequest feeRequest)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->CreateFee");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->CreateFee");

            // verify the required parameter 'feeRequest' is set
            if (feeRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'feeRequest' when calling FundsApi->CreateFee");

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
            localVarRequestOptions.Data = feeRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Post<Fee>("/api/funds/{scope}/{code}/fees", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateFee", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateFee: Create a Fee. Create the given Fee.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeRequest">The Fee to create.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Fee</returns>
        public async System.Threading.Tasks.Task<Fee> CreateFeeAsync(string scope, string code, FeeRequest feeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<Fee> localVarResponse = await CreateFeeWithHttpInfoAsync(scope, code, feeRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateFee: Create a Fee. Create the given Fee.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeRequest">The Fee to create.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Fee)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<Fee>> CreateFeeWithHttpInfoAsync(string scope, string code, FeeRequest feeRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->CreateFee");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->CreateFee");

            // verify the required parameter 'feeRequest' is set
            if (feeRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'feeRequest' when calling FundsApi->CreateFee");


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
            localVarRequestOptions.Data = feeRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Fee>("/api/funds/{scope}/{code}/fees", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateFee", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateFund: Create a Fund. Create the given Fund.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="fundRequest">The definition of the Fund.</param>
        /// <returns>Fund</returns>
        public Fund CreateFund(string scope, FundRequest fundRequest)
        {
            Lusid.Sdk.Client.ApiResponse<Fund> localVarResponse = CreateFundWithHttpInfo(scope, fundRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateFund: Create a Fund. Create the given Fund.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="fundRequest">The definition of the Fund.</param>
        /// <returns>ApiResponse of Fund</returns>
        public Lusid.Sdk.Client.ApiResponse<Fund> CreateFundWithHttpInfo(string scope, FundRequest fundRequest)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->CreateFund");

            // verify the required parameter 'fundRequest' is set
            if (fundRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'fundRequest' when calling FundsApi->CreateFund");

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
            localVarRequestOptions.Data = fundRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Post<Fund>("/api/funds/{scope}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateFund", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateFund: Create a Fund. Create the given Fund.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="fundRequest">The definition of the Fund.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Fund</returns>
        public async System.Threading.Tasks.Task<Fund> CreateFundAsync(string scope, FundRequest fundRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<Fund> localVarResponse = await CreateFundWithHttpInfoAsync(scope, fundRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] CreateFund: Create a Fund. Create the given Fund.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="fundRequest">The definition of the Fund.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Fund)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<Fund>> CreateFundWithHttpInfoAsync(string scope, FundRequest fundRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->CreateFund");

            // verify the required parameter 'fundRequest' is set
            if (fundRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'fundRequest' when calling FundsApi->CreateFund");


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
            localVarRequestOptions.Data = fundRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<Fund>("/api/funds/{scope}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("CreateFund", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteFee: Delete a Fee. Delete the given Fee.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to be deleted.</param>
        /// <returns>DeletedEntityResponse</returns>
        public DeletedEntityResponse DeleteFee(string scope, string code, string feeCode)
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = DeleteFeeWithHttpInfo(scope, code, feeCode);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteFee: Delete a Fee. Delete the given Fee.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to be deleted.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> DeleteFeeWithHttpInfo(string scope, string code, string feeCode)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->DeleteFee");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->DeleteFee");

            // verify the required parameter 'feeCode' is set
            if (feeCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'feeCode' when calling FundsApi->DeleteFee");

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
            localVarRequestOptions.PathParameters.Add("feeCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(feeCode)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Delete<DeletedEntityResponse>("/api/funds/{scope}/{code}/fees/{feeCode}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteFee", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteFee: Delete a Fee. Delete the given Fee.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to be deleted.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        public async System.Threading.Tasks.Task<DeletedEntityResponse> DeleteFeeAsync(string scope, string code, string feeCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = await DeleteFeeWithHttpInfoAsync(scope, code, feeCode, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteFee: Delete a Fee. Delete the given Fee.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to be deleted.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse>> DeleteFeeWithHttpInfoAsync(string scope, string code, string feeCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->DeleteFee");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->DeleteFee");

            // verify the required parameter 'feeCode' is set
            if (feeCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'feeCode' when calling FundsApi->DeleteFee");


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
            localVarRequestOptions.PathParameters.Add("feeCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(feeCode)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<DeletedEntityResponse>("/api/funds/{scope}/{code}/fees/{feeCode}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteFee", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteFund: Delete a Fund. Delete the given Fund.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to be deleted.</param>
        /// <param name="code">The code of the Fund to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <returns>DeletedEntityResponse</returns>
        public DeletedEntityResponse DeleteFund(string scope, string code)
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = DeleteFundWithHttpInfo(scope, code);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteFund: Delete a Fund. Delete the given Fund.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to be deleted.</param>
        /// <param name="code">The code of the Fund to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> DeleteFundWithHttpInfo(string scope, string code)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->DeleteFund");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->DeleteFund");

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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Delete<DeletedEntityResponse>("/api/funds/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteFund", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteFund: Delete a Fund. Delete the given Fund.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to be deleted.</param>
        /// <param name="code">The code of the Fund to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        public async System.Threading.Tasks.Task<DeletedEntityResponse> DeleteFundAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = await DeleteFundWithHttpInfoAsync(scope, code, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteFund: Delete a Fund. Delete the given Fund.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to be deleted.</param>
        /// <param name="code">The code of the Fund to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse>> DeleteFundWithHttpInfoAsync(string scope, string code, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->DeleteFund");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->DeleteFund");


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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<DeletedEntityResponse>("/api/funds/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteFund", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteValuationPoint: Delete a Valuation Point. Deletes the given Valuation Point.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund for the valuation point to be deleted.</param>
        /// <param name="code">The code of the Fund containing the Valuation Point to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="diaryEntryCode">The diary entry code for the valuation Point to be deleted.</param>
        /// <returns>DeletedEntityResponse</returns>
        public DeletedEntityResponse DeleteValuationPoint(string scope, string code, string diaryEntryCode)
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = DeleteValuationPointWithHttpInfo(scope, code, diaryEntryCode);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteValuationPoint: Delete a Valuation Point. Deletes the given Valuation Point.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund for the valuation point to be deleted.</param>
        /// <param name="code">The code of the Fund containing the Valuation Point to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="diaryEntryCode">The diary entry code for the valuation Point to be deleted.</param>
        /// <returns>ApiResponse of DeletedEntityResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> DeleteValuationPointWithHttpInfo(string scope, string code, string diaryEntryCode)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->DeleteValuationPoint");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->DeleteValuationPoint");

            // verify the required parameter 'diaryEntryCode' is set
            if (diaryEntryCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'diaryEntryCode' when calling FundsApi->DeleteValuationPoint");

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
            localVarRequestOptions.PathParameters.Add("diaryEntryCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(diaryEntryCode)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Delete<DeletedEntityResponse>("/api/funds/{scope}/{code}/valuationpoints/{diaryEntryCode}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteValuationPoint", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteValuationPoint: Delete a Valuation Point. Deletes the given Valuation Point.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund for the valuation point to be deleted.</param>
        /// <param name="code">The code of the Fund containing the Valuation Point to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="diaryEntryCode">The diary entry code for the valuation Point to be deleted.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DeletedEntityResponse</returns>
        public async System.Threading.Tasks.Task<DeletedEntityResponse> DeleteValuationPointAsync(string scope, string code, string diaryEntryCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse> localVarResponse = await DeleteValuationPointWithHttpInfoAsync(scope, code, diaryEntryCode, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] DeleteValuationPoint: Delete a Valuation Point. Deletes the given Valuation Point.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund for the valuation point to be deleted.</param>
        /// <param name="code">The code of the Fund containing the Valuation Point to be deleted. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="diaryEntryCode">The diary entry code for the valuation Point to be deleted.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DeletedEntityResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DeletedEntityResponse>> DeleteValuationPointWithHttpInfoAsync(string scope, string code, string diaryEntryCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->DeleteValuationPoint");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->DeleteValuationPoint");

            // verify the required parameter 'diaryEntryCode' is set
            if (diaryEntryCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'diaryEntryCode' when calling FundsApi->DeleteValuationPoint");


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
            localVarRequestOptions.PathParameters.Add("diaryEntryCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(diaryEntryCode)); // path parameter

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.DeleteAsync<DeletedEntityResponse>("/api/funds/{scope}/{code}/valuationpoints/{diaryEntryCode}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteValuationPoint", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] FinaliseCandidateValuationPoint: Finalise Candidate. Moves a &#39;Candidate&#39; status Valuation Point to status &#39;Final&#39;.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the diary entry code to mark as final.</param>
        /// <returns>ValuationPointDataResponse</returns>
        public ValuationPointDataResponse FinaliseCandidateValuationPoint(string scope, string code, ValuationPointDataRequest valuationPointDataRequest)
        {
            Lusid.Sdk.Client.ApiResponse<ValuationPointDataResponse> localVarResponse = FinaliseCandidateValuationPointWithHttpInfo(scope, code, valuationPointDataRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] FinaliseCandidateValuationPoint: Finalise Candidate. Moves a &#39;Candidate&#39; status Valuation Point to status &#39;Final&#39;.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the diary entry code to mark as final.</param>
        /// <returns>ApiResponse of ValuationPointDataResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<ValuationPointDataResponse> FinaliseCandidateValuationPointWithHttpInfo(string scope, string code, ValuationPointDataRequest valuationPointDataRequest)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->FinaliseCandidateValuationPoint");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->FinaliseCandidateValuationPoint");

            // verify the required parameter 'valuationPointDataRequest' is set
            if (valuationPointDataRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'valuationPointDataRequest' when calling FundsApi->FinaliseCandidateValuationPoint");

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
            localVarRequestOptions.Data = valuationPointDataRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ValuationPointDataResponse>("/api/funds/{scope}/{code}/valuationpoints/$finalisecandidate", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FinaliseCandidateValuationPoint", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] FinaliseCandidateValuationPoint: Finalise Candidate. Moves a &#39;Candidate&#39; status Valuation Point to status &#39;Final&#39;.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the diary entry code to mark as final.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ValuationPointDataResponse</returns>
        public async System.Threading.Tasks.Task<ValuationPointDataResponse> FinaliseCandidateValuationPointAsync(string scope, string code, ValuationPointDataRequest valuationPointDataRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ValuationPointDataResponse> localVarResponse = await FinaliseCandidateValuationPointWithHttpInfoAsync(scope, code, valuationPointDataRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] FinaliseCandidateValuationPoint: Finalise Candidate. Moves a &#39;Candidate&#39; status Valuation Point to status &#39;Final&#39;.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataRequest">The valuationPointDataRequest which contains the diary entry code to mark as final.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ValuationPointDataResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ValuationPointDataResponse>> FinaliseCandidateValuationPointWithHttpInfoAsync(string scope, string code, ValuationPointDataRequest valuationPointDataRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->FinaliseCandidateValuationPoint");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->FinaliseCandidateValuationPoint");

            // verify the required parameter 'valuationPointDataRequest' is set
            if (valuationPointDataRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'valuationPointDataRequest' when calling FundsApi->FinaliseCandidateValuationPoint");


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
            localVarRequestOptions.Data = valuationPointDataRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ValuationPointDataResponse>("/api/funds/{scope}/{code}/valuationpoints/$finalisecandidate", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("FinaliseCandidateValuationPoint", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetFee: Get a Fee for a specified Fund. Retrieve a fee for a specified Fund
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fee properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fee. Defaults to returning the latest version of the Fee if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto the Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <returns>Fee</returns>
        public Fee GetFee(string scope, string code, string feeCode, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>))
        {
            Lusid.Sdk.Client.ApiResponse<Fee> localVarResponse = GetFeeWithHttpInfo(scope, code, feeCode, effectiveAt, asAt, propertyKeys);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetFee: Get a Fee for a specified Fund. Retrieve a fee for a specified Fund
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fee properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fee. Defaults to returning the latest version of the Fee if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto the Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <returns>ApiResponse of Fee</returns>
        public Lusid.Sdk.Client.ApiResponse<Fee> GetFeeWithHttpInfo(string scope, string code, string feeCode, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->GetFee");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->GetFee");

            // verify the required parameter 'feeCode' is set
            if (feeCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'feeCode' when calling FundsApi->GetFee");

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
            localVarRequestOptions.PathParameters.Add("feeCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(feeCode)); // path parameter
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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Get<Fee>("/api/funds/{scope}/{code}/fees/{feeCode}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFee", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetFee: Get a Fee for a specified Fund. Retrieve a fee for a specified Fund
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fee properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fee. Defaults to returning the latest version of the Fee if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto the Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Fee</returns>
        public async System.Threading.Tasks.Task<Fee> GetFeeAsync(string scope, string code, string feeCode, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<Fee> localVarResponse = await GetFeeWithHttpInfoAsync(scope, code, feeCode, effectiveAt, asAt, propertyKeys, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetFee: Get a Fee for a specified Fund. Retrieve a fee for a specified Fund
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fee properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fee. Defaults to returning the latest version of the Fee if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto the Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Fee)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<Fee>> GetFeeWithHttpInfoAsync(string scope, string code, string feeCode, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->GetFee");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->GetFee");

            // verify the required parameter 'feeCode' is set
            if (feeCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'feeCode' when calling FundsApi->GetFee");


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
            localVarRequestOptions.PathParameters.Add("feeCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(feeCode)); // path parameter
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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Fee>("/api/funds/{scope}/{code}/fees/{feeCode}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFee", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetFund: Get a Fund. Retrieve the definition of a particular Fund.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fund properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto the Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <returns>Fund</returns>
        public Fund GetFund(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>))
        {
            Lusid.Sdk.Client.ApiResponse<Fund> localVarResponse = GetFundWithHttpInfo(scope, code, effectiveAt, asAt, propertyKeys);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetFund: Get a Fund. Retrieve the definition of a particular Fund.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fund properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto the Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <returns>ApiResponse of Fund</returns>
        public Lusid.Sdk.Client.ApiResponse<Fund> GetFundWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->GetFund");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->GetFund");

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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Get<Fund>("/api/funds/{scope}/{code}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFund", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetFund: Get a Fund. Retrieve the definition of a particular Fund.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fund properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto the Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Fund</returns>
        public async System.Threading.Tasks.Task<Fund> GetFundAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<Fund> localVarResponse = await GetFundWithHttpInfoAsync(scope, code, effectiveAt, asAt, propertyKeys, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetFund: Get a Fund. Retrieve the definition of a particular Fund.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to retrieve the Fund properties. Defaults to the current LUSID system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto the Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. If no properties are specified, then no properties will be returned. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Fund)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<Fund>> GetFundWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->GetFund");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->GetFund");


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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<Fund>("/api/funds/{scope}/{code}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetFund", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetValuationPointData: Get Valuation Point Data for a Fund. Retrieves the Valuation Point data for a date or specified Diary Entry Id.  The endpoint will internally extract all &#39;Assets&#39; and &#39;Liabilities&#39; from the related ABOR&#39;s Trial balance to produce a GAV.  Start date will be assumed from the last &#39;official&#39; DiaryEntry and EndDate will be as provided.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataQueryParameters">The arguments to use for querying the Valuation Point data</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <returns>ValuationPointDataResponse</returns>
        public ValuationPointDataResponse GetValuationPointData(string scope, string code, ValuationPointDataQueryParameters valuationPointDataQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?))
        {
            Lusid.Sdk.Client.ApiResponse<ValuationPointDataResponse> localVarResponse = GetValuationPointDataWithHttpInfo(scope, code, valuationPointDataQueryParameters, asAt);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetValuationPointData: Get Valuation Point Data for a Fund. Retrieves the Valuation Point data for a date or specified Diary Entry Id.  The endpoint will internally extract all &#39;Assets&#39; and &#39;Liabilities&#39; from the related ABOR&#39;s Trial balance to produce a GAV.  Start date will be assumed from the last &#39;official&#39; DiaryEntry and EndDate will be as provided.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataQueryParameters">The arguments to use for querying the Valuation Point data</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <returns>ApiResponse of ValuationPointDataResponse</returns>
        public Lusid.Sdk.Client.ApiResponse<ValuationPointDataResponse> GetValuationPointDataWithHttpInfo(string scope, string code, ValuationPointDataQueryParameters valuationPointDataQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->GetValuationPointData");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->GetValuationPointData");

            // verify the required parameter 'valuationPointDataQueryParameters' is set
            if (valuationPointDataQueryParameters == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'valuationPointDataQueryParameters' when calling FundsApi->GetValuationPointData");

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
            localVarRequestOptions.Data = valuationPointDataQueryParameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Post<ValuationPointDataResponse>("/api/funds/{scope}/{code}/valuationpoints/$query", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetValuationPointData", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetValuationPointData: Get Valuation Point Data for a Fund. Retrieves the Valuation Point data for a date or specified Diary Entry Id.  The endpoint will internally extract all &#39;Assets&#39; and &#39;Liabilities&#39; from the related ABOR&#39;s Trial balance to produce a GAV.  Start date will be assumed from the last &#39;official&#39; DiaryEntry and EndDate will be as provided.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataQueryParameters">The arguments to use for querying the Valuation Point data</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ValuationPointDataResponse</returns>
        public async System.Threading.Tasks.Task<ValuationPointDataResponse> GetValuationPointDataAsync(string scope, string code, ValuationPointDataQueryParameters valuationPointDataQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<ValuationPointDataResponse> localVarResponse = await GetValuationPointDataWithHttpInfoAsync(scope, code, valuationPointDataQueryParameters, asAt, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] GetValuationPointData: Get Valuation Point Data for a Fund. Retrieves the Valuation Point data for a date or specified Diary Entry Id.  The endpoint will internally extract all &#39;Assets&#39; and &#39;Liabilities&#39; from the related ABOR&#39;s Trial balance to produce a GAV.  Start date will be assumed from the last &#39;official&#39; DiaryEntry and EndDate will be as provided.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="valuationPointDataQueryParameters">The arguments to use for querying the Valuation Point data</param>
        /// <param name="asAt">The asAt datetime at which to retrieve the Fund definition. Defaults to returning the latest version of the Fund definition if not specified. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (ValuationPointDataResponse)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<ValuationPointDataResponse>> GetValuationPointDataWithHttpInfoAsync(string scope, string code, ValuationPointDataQueryParameters valuationPointDataQueryParameters, DateTimeOffset? asAt = default(DateTimeOffset?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->GetValuationPointData");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->GetValuationPointData");

            // verify the required parameter 'valuationPointDataQueryParameters' is set
            if (valuationPointDataQueryParameters == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'valuationPointDataQueryParameters' when calling FundsApi->GetValuationPointData");


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
            localVarRequestOptions.Data = valuationPointDataQueryParameters;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<ValuationPointDataResponse>("/api/funds/{scope}/{code}/valuationpoints/$query", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetValuationPointData", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListFees: List Fees for a specified Fund. List all the Fees matching a particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Fees. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Fees. Defaults to returning the latest version of each Fee if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing fees; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the treatment, specify \&quot;treatment eq &#39;Monthly&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto each Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. (optional)</param>
        /// <returns>PagedResourceListOfFee</returns>
        public PagedResourceListOfFee ListFees(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfFee> localVarResponse = ListFeesWithHttpInfo(scope, code, effectiveAt, asAt, page, limit, filter, sortBy, propertyKeys);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListFees: List Fees for a specified Fund. List all the Fees matching a particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Fees. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Fees. Defaults to returning the latest version of each Fee if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing fees; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the treatment, specify \&quot;treatment eq &#39;Monthly&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto each Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfFee</returns>
        public Lusid.Sdk.Client.ApiResponse<PagedResourceListOfFee> ListFeesWithHttpInfo(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->ListFees");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->ListFees");

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
            if (sortBy != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "sortBy", sortBy));
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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Get<PagedResourceListOfFee>("/api/funds/{scope}/{code}/fees", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListFees", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListFees: List Fees for a specified Fund. List all the Fees matching a particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Fees. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Fees. Defaults to returning the latest version of each Fee if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing fees; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the treatment, specify \&quot;treatment eq &#39;Monthly&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto each Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfFee</returns>
        public async System.Threading.Tasks.Task<PagedResourceListOfFee> ListFeesAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfFee> localVarResponse = await ListFeesWithHttpInfoAsync(scope, code, effectiveAt, asAt, page, limit, filter, sortBy, propertyKeys, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListFees: List Fees for a specified Fund. List all the Fees matching a particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Fees. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Fees. Defaults to returning the latest version of each Fee if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing fees; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the treatment, specify \&quot;treatment eq &#39;Monthly&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fee&#39; domain to decorate onto each Fee.              These must take the format {domain}/{scope}/{code}, for example &#39;Fee/Account/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfFee)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<PagedResourceListOfFee>> ListFeesWithHttpInfoAsync(string scope, string code, DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->ListFees");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->ListFees");


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
            if (sortBy != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "sortBy", sortBy));
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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<PagedResourceListOfFee>("/api/funds/{scope}/{code}/fees", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListFees", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListFunds: List Funds. List all the Funds matching particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Funds. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Funds. Defaults to returning the latest version of each Fund if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Funds; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Fund type, specify \&quot;id.Code eq &#39;Fund1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto each Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. (optional)</param>
        /// <returns>PagedResourceListOfFund</returns>
        public PagedResourceListOfFund ListFunds(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfFund> localVarResponse = ListFundsWithHttpInfo(effectiveAt, asAt, page, limit, filter, sortBy, propertyKeys);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListFunds: List Funds. List all the Funds matching particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Funds. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Funds. Defaults to returning the latest version of each Fund if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Funds; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Fund type, specify \&quot;id.Code eq &#39;Fund1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto each Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. (optional)</param>
        /// <returns>ApiResponse of PagedResourceListOfFund</returns>
        public Lusid.Sdk.Client.ApiResponse<PagedResourceListOfFund> ListFundsWithHttpInfo(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>))
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
            if (sortBy != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "sortBy", sortBy));
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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Get<PagedResourceListOfFund>("/api/funds", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListFunds", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListFunds: List Funds. List all the Funds matching particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Funds. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Funds. Defaults to returning the latest version of each Fund if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Funds; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Fund type, specify \&quot;id.Code eq &#39;Fund1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto each Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of PagedResourceListOfFund</returns>
        public async System.Threading.Tasks.Task<PagedResourceListOfFund> ListFundsAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<PagedResourceListOfFund> localVarResponse = await ListFundsWithHttpInfoAsync(effectiveAt, asAt, page, limit, filter, sortBy, propertyKeys, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] ListFunds: List Funds. List all the Funds matching particular criteria.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="effectiveAt">The effective datetime or cut label at which to list the TimeVariant properties for the Funds. Defaults to the current LUSID              system datetime if not specified. (optional)</param>
        /// <param name="asAt">The asAt datetime at which to list the Funds. Defaults to returning the latest version of each Fund if not specified. (optional)</param>
        /// <param name="page">The pagination token to use to continue listing Funds; this              value is returned from the previous call. If a pagination token is provided, the filter, effectiveAt              and asAt fields must not have changed since the original request. (optional)</param>
        /// <param name="limit">When paginating, limit the results to this number. Defaults to 100 if not specified. (optional)</param>
        /// <param name="filter">Expression to filter the results.              For example, to filter on the Fund type, specify \&quot;id.Code eq &#39;Fund1&#39;\&quot;. For more information about filtering              results, see https://support.lusid.com/knowledgebase/article/KA-01914. (optional)</param>
        /// <param name="sortBy">A list of field names or properties to sort by, each suffixed by \&quot; ASC\&quot; or \&quot; DESC\&quot; (optional)</param>
        /// <param name="propertyKeys">A list of property keys from the &#39;Fund&#39; domain to decorate onto each Fund.              These must take the format {domain}/{scope}/{code}, for example &#39;Fund/Manager/Id&#39;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (PagedResourceListOfFund)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<PagedResourceListOfFund>> ListFundsWithHttpInfoAsync(DateTimeOrCutLabel effectiveAt = default(DateTimeOrCutLabel), DateTimeOffset? asAt = default(DateTimeOffset?), string page = default(string), int? limit = default(int?), string filter = default(string), List<string> sortBy = default(List<string>), List<string> propertyKeys = default(List<string>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
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
            if (sortBy != null)
            {
                localVarRequestOptions.QueryParameters.Add(Lusid.Sdk.Client.ClientUtils.ParameterToMultiMap("multi", "sortBy", sortBy));
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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<PagedResourceListOfFund>("/api/funds", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("ListFunds", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] PatchFee: Patch Fee. Create or update certain fields for a particular Fee.  The behaviour is defined by the JSON Patch specification.                Currently supported fields are: EndDate.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="operation">The json patch document. For more information see: https://datatracker.ietf.org/doc/html/rfc6902.</param>
        /// <returns>Fee</returns>
        public Fee PatchFee(string scope, string code, string feeCode, List<Operation> operation)
        {
            Lusid.Sdk.Client.ApiResponse<Fee> localVarResponse = PatchFeeWithHttpInfo(scope, code, feeCode, operation);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] PatchFee: Patch Fee. Create or update certain fields for a particular Fee.  The behaviour is defined by the JSON Patch specification.                Currently supported fields are: EndDate.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="operation">The json patch document. For more information see: https://datatracker.ietf.org/doc/html/rfc6902.</param>
        /// <returns>ApiResponse of Fee</returns>
        public Lusid.Sdk.Client.ApiResponse<Fee> PatchFeeWithHttpInfo(string scope, string code, string feeCode, List<Operation> operation)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->PatchFee");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->PatchFee");

            // verify the required parameter 'feeCode' is set
            if (feeCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'feeCode' when calling FundsApi->PatchFee");

            // verify the required parameter 'operation' is set
            if (operation == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'operation' when calling FundsApi->PatchFee");

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
            localVarRequestOptions.PathParameters.Add("feeCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(feeCode)); // path parameter
            localVarRequestOptions.Data = operation;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Patch<Fee>("/api/funds/{scope}/{code}/fees/{feeCode}", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PatchFee", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] PatchFee: Patch Fee. Create or update certain fields for a particular Fee.  The behaviour is defined by the JSON Patch specification.                Currently supported fields are: EndDate.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="operation">The json patch document. For more information see: https://datatracker.ietf.org/doc/html/rfc6902.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Fee</returns>
        public async System.Threading.Tasks.Task<Fee> PatchFeeAsync(string scope, string code, string feeCode, List<Operation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<Fee> localVarResponse = await PatchFeeWithHttpInfoAsync(scope, code, feeCode, operation, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] PatchFee: Patch Fee. Create or update certain fields for a particular Fee.  The behaviour is defined by the JSON Patch specification.                Currently supported fields are: EndDate.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee.</param>
        /// <param name="operation">The json patch document. For more information see: https://datatracker.ietf.org/doc/html/rfc6902.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Fee)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<Fee>> PatchFeeWithHttpInfoAsync(string scope, string code, string feeCode, List<Operation> operation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->PatchFee");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->PatchFee");

            // verify the required parameter 'feeCode' is set
            if (feeCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'feeCode' when calling FundsApi->PatchFee");

            // verify the required parameter 'operation' is set
            if (operation == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'operation' when calling FundsApi->PatchFee");


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
            localVarRequestOptions.PathParameters.Add("feeCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(feeCode)); // path parameter
            localVarRequestOptions.Data = operation;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PatchAsync<Fee>("/api/funds/{scope}/{code}/fees/{feeCode}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PatchFee", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] SetShareClassInstruments: Set the ShareClass Instruments on a fund. Update the ShareClass Instruments on an existing fund with the set of instruments provided.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="setShareClassInstrumentsRequest">The scopes and instrument identifiers for the instruments to be set.</param>
        /// <returns>Fund</returns>
        public Fund SetShareClassInstruments(string scope, string code, SetShareClassInstrumentsRequest setShareClassInstrumentsRequest)
        {
            Lusid.Sdk.Client.ApiResponse<Fund> localVarResponse = SetShareClassInstrumentsWithHttpInfo(scope, code, setShareClassInstrumentsRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] SetShareClassInstruments: Set the ShareClass Instruments on a fund. Update the ShareClass Instruments on an existing fund with the set of instruments provided.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="setShareClassInstrumentsRequest">The scopes and instrument identifiers for the instruments to be set.</param>
        /// <returns>ApiResponse of Fund</returns>
        public Lusid.Sdk.Client.ApiResponse<Fund> SetShareClassInstrumentsWithHttpInfo(string scope, string code, SetShareClassInstrumentsRequest setShareClassInstrumentsRequest)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->SetShareClassInstruments");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->SetShareClassInstruments");

            // verify the required parameter 'setShareClassInstrumentsRequest' is set
            if (setShareClassInstrumentsRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'setShareClassInstrumentsRequest' when calling FundsApi->SetShareClassInstruments");

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
            localVarRequestOptions.Data = setShareClassInstrumentsRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Put<Fund>("/api/funds/{scope}/{code}/shareclasses", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SetShareClassInstruments", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] SetShareClassInstruments: Set the ShareClass Instruments on a fund. Update the ShareClass Instruments on an existing fund with the set of instruments provided.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="setShareClassInstrumentsRequest">The scopes and instrument identifiers for the instruments to be set.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Fund</returns>
        public async System.Threading.Tasks.Task<Fund> SetShareClassInstrumentsAsync(string scope, string code, SetShareClassInstrumentsRequest setShareClassInstrumentsRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<Fund> localVarResponse = await SetShareClassInstrumentsWithHttpInfoAsync(scope, code, setShareClassInstrumentsRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] SetShareClassInstruments: Set the ShareClass Instruments on a fund. Update the ShareClass Instruments on an existing fund with the set of instruments provided.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund.</param>
        /// <param name="setShareClassInstrumentsRequest">The scopes and instrument identifiers for the instruments to be set.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Fund)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<Fund>> SetShareClassInstrumentsWithHttpInfoAsync(string scope, string code, SetShareClassInstrumentsRequest setShareClassInstrumentsRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->SetShareClassInstruments");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->SetShareClassInstruments");

            // verify the required parameter 'setShareClassInstrumentsRequest' is set
            if (setShareClassInstrumentsRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'setShareClassInstrumentsRequest' when calling FundsApi->SetShareClassInstruments");


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
            localVarRequestOptions.Data = setShareClassInstrumentsRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PutAsync<Fund>("/api/funds/{scope}/{code}/shareclasses", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("SetShareClassInstruments", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertDiaryEntryTypeValuationPoint: Upsert Valuation Point. Update or insert the estimate Valuation Point.                If the Valuation Point does not exist, this method will create it in estimate state.                If the Valuation Point already exists and is in estimate state, the Valuation Point will be updated with the newly specified information in this request.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="upsertValuationPointRequest">The Valuation Point Estimate definition to Upsert</param>
        /// <returns>DiaryEntry</returns>
        public DiaryEntry UpsertDiaryEntryTypeValuationPoint(string scope, string code, UpsertValuationPointRequest upsertValuationPointRequest)
        {
            Lusid.Sdk.Client.ApiResponse<DiaryEntry> localVarResponse = UpsertDiaryEntryTypeValuationPointWithHttpInfo(scope, code, upsertValuationPointRequest);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertDiaryEntryTypeValuationPoint: Upsert Valuation Point. Update or insert the estimate Valuation Point.                If the Valuation Point does not exist, this method will create it in estimate state.                If the Valuation Point already exists and is in estimate state, the Valuation Point will be updated with the newly specified information in this request.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="upsertValuationPointRequest">The Valuation Point Estimate definition to Upsert</param>
        /// <returns>ApiResponse of DiaryEntry</returns>
        public Lusid.Sdk.Client.ApiResponse<DiaryEntry> UpsertDiaryEntryTypeValuationPointWithHttpInfo(string scope, string code, UpsertValuationPointRequest upsertValuationPointRequest)
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->UpsertDiaryEntryTypeValuationPoint");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->UpsertDiaryEntryTypeValuationPoint");

            // verify the required parameter 'upsertValuationPointRequest' is set
            if (upsertValuationPointRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'upsertValuationPointRequest' when calling FundsApi->UpsertDiaryEntryTypeValuationPoint");

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
            localVarRequestOptions.Data = upsertValuationPointRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Post<DiaryEntry>("/api/funds/{scope}/{code}/valuationpoints", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertDiaryEntryTypeValuationPoint", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertDiaryEntryTypeValuationPoint: Upsert Valuation Point. Update or insert the estimate Valuation Point.                If the Valuation Point does not exist, this method will create it in estimate state.                If the Valuation Point already exists and is in estimate state, the Valuation Point will be updated with the newly specified information in this request.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="upsertValuationPointRequest">The Valuation Point Estimate definition to Upsert</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of DiaryEntry</returns>
        public async System.Threading.Tasks.Task<DiaryEntry> UpsertDiaryEntryTypeValuationPointAsync(string scope, string code, UpsertValuationPointRequest upsertValuationPointRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<DiaryEntry> localVarResponse = await UpsertDiaryEntryTypeValuationPointWithHttpInfoAsync(scope, code, upsertValuationPointRequest, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertDiaryEntryTypeValuationPoint: Upsert Valuation Point. Update or insert the estimate Valuation Point.                If the Valuation Point does not exist, this method will create it in estimate state.                If the Valuation Point already exists and is in estimate state, the Valuation Point will be updated with the newly specified information in this request.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="upsertValuationPointRequest">The Valuation Point Estimate definition to Upsert</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (DiaryEntry)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<DiaryEntry>> UpsertDiaryEntryTypeValuationPointWithHttpInfoAsync(string scope, string code, UpsertValuationPointRequest upsertValuationPointRequest, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->UpsertDiaryEntryTypeValuationPoint");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->UpsertDiaryEntryTypeValuationPoint");

            // verify the required parameter 'upsertValuationPointRequest' is set
            if (upsertValuationPointRequest == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'upsertValuationPointRequest' when calling FundsApi->UpsertDiaryEntryTypeValuationPoint");


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
            localVarRequestOptions.Data = upsertValuationPointRequest;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<DiaryEntry>("/api/funds/{scope}/{code}/valuationpoints", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertDiaryEntryTypeValuationPoint", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertFeeProperties: Upsert Fee properties. Update or insert one or more properties onto a single Fee. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fee&#39;.                Upserting a property that exists for an Fee, with a null value, will delete the instance of the property for that group.       Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to update or insert the properties onto.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fee. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fee/Manager/Id\&quot;. (optional)</param>
        /// <returns>FeeProperties</returns>
        public FeeProperties UpsertFeeProperties(string scope, string code, string feeCode, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>))
        {
            Lusid.Sdk.Client.ApiResponse<FeeProperties> localVarResponse = UpsertFeePropertiesWithHttpInfo(scope, code, feeCode, requestBody);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertFeeProperties: Upsert Fee properties. Update or insert one or more properties onto a single Fee. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fee&#39;.                Upserting a property that exists for an Fee, with a null value, will delete the instance of the property for that group.       Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to update or insert the properties onto.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fee. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fee/Manager/Id\&quot;. (optional)</param>
        /// <returns>ApiResponse of FeeProperties</returns>
        public Lusid.Sdk.Client.ApiResponse<FeeProperties> UpsertFeePropertiesWithHttpInfo(string scope, string code, string feeCode, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->UpsertFeeProperties");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->UpsertFeeProperties");

            // verify the required parameter 'feeCode' is set
            if (feeCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'feeCode' when calling FundsApi->UpsertFeeProperties");

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
            localVarRequestOptions.PathParameters.Add("feeCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(feeCode)); // path parameter
            localVarRequestOptions.Data = requestBody;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Post<FeeProperties>("/api/funds/{scope}/{code}/fees/{feeCode}/properties/$upsert", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertFeeProperties", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertFeeProperties: Upsert Fee properties. Update or insert one or more properties onto a single Fee. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fee&#39;.                Upserting a property that exists for an Fee, with a null value, will delete the instance of the property for that group.       Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to update or insert the properties onto.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fee. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fee/Manager/Id\&quot;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FeeProperties</returns>
        public async System.Threading.Tasks.Task<FeeProperties> UpsertFeePropertiesAsync(string scope, string code, string feeCode, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<FeeProperties> localVarResponse = await UpsertFeePropertiesWithHttpInfoAsync(scope, code, feeCode, requestBody, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertFeeProperties: Upsert Fee properties. Update or insert one or more properties onto a single Fee. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fee&#39;.                Upserting a property that exists for an Fee, with a null value, will delete the instance of the property for that group.       Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund.</param>
        /// <param name="code">The code of the Fund. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="feeCode">The code of the Fee to update or insert the properties onto.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fee. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fee/Manager/Id\&quot;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FeeProperties)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<FeeProperties>> UpsertFeePropertiesWithHttpInfoAsync(string scope, string code, string feeCode, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->UpsertFeeProperties");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->UpsertFeeProperties");

            // verify the required parameter 'feeCode' is set
            if (feeCode == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'feeCode' when calling FundsApi->UpsertFeeProperties");


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
            localVarRequestOptions.PathParameters.Add("feeCode", Lusid.Sdk.Client.ClientUtils.ParameterToString(feeCode)); // path parameter
            localVarRequestOptions.Data = requestBody;

            // authentication (oauth2) required
            // oauth required
            if (!String.IsNullOrEmpty(this.Configuration.AccessToken))
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", "Bearer " + this.Configuration.AccessToken);
            }

            //  set the LUSID header
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Language", "C#");
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<FeeProperties>("/api/funds/{scope}/{code}/fees/{feeCode}/properties/$upsert", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertFeeProperties", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertFundProperties: Upsert Fund properties. Update or insert one or more properties onto a single Fund. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fund&#39;.                Upserting a property that exists for an Fund, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to update or insert the properties onto.</param>
        /// <param name="code">The code of the Fund to update or insert the properties onto. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fund. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fund/Manager/Id\&quot;. (optional)</param>
        /// <returns>FundProperties</returns>
        public FundProperties UpsertFundProperties(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>))
        {
            Lusid.Sdk.Client.ApiResponse<FundProperties> localVarResponse = UpsertFundPropertiesWithHttpInfo(scope, code, requestBody);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertFundProperties: Upsert Fund properties. Update or insert one or more properties onto a single Fund. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fund&#39;.                Upserting a property that exists for an Fund, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to update or insert the properties onto.</param>
        /// <param name="code">The code of the Fund to update or insert the properties onto. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fund. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fund/Manager/Id\&quot;. (optional)</param>
        /// <returns>ApiResponse of FundProperties</returns>
        public Lusid.Sdk.Client.ApiResponse<FundProperties> UpsertFundPropertiesWithHttpInfo(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->UpsertFundProperties");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->UpsertFundProperties");

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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request
            var localVarResponse = this.Client.Post<FundProperties>("/api/funds/{scope}/{code}/properties/$upsert", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertFundProperties", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertFundProperties: Upsert Fund properties. Update or insert one or more properties onto a single Fund. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fund&#39;.                Upserting a property that exists for an Fund, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to update or insert the properties onto.</param>
        /// <param name="code">The code of the Fund to update or insert the properties onto. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fund. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fund/Manager/Id\&quot;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of FundProperties</returns>
        public async System.Threading.Tasks.Task<FundProperties> UpsertFundPropertiesAsync(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Lusid.Sdk.Client.ApiResponse<FundProperties> localVarResponse = await UpsertFundPropertiesWithHttpInfoAsync(scope, code, requestBody, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// [EXPERIMENTAL] UpsertFundProperties: Upsert Fund properties. Update or insert one or more properties onto a single Fund. A property will be updated if it  already exists and inserted if it does not. All properties must be of the domain &#39;Fund&#39;.                Upserting a property that exists for an Fund, with a null value, will delete the instance of the property for that group.                Properties have an &lt;i&gt;effectiveFrom&lt;/i&gt; datetime for which the property is valid, and an &lt;i&gt;effectiveUntil&lt;/i&gt;  datetime until which the property is valid. Not supplying an &lt;i&gt;effectiveUntil&lt;/i&gt; datetime results in the property being  valid indefinitely, or until the next &lt;i&gt;effectiveFrom&lt;/i&gt; datetime of the property.
        /// </summary>
        /// <exception cref="Lusid.Sdk.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="scope">The scope of the Fund to update or insert the properties onto.</param>
        /// <param name="code">The code of the Fund to update or insert the properties onto. Together with the scope this uniquely identifies the Fund.</param>
        /// <param name="requestBody">The properties to be updated or inserted onto the Fund. Each property in               the request must be keyed by its unique property key. This has the format {domain}/{scope}/{code} e.g. \&quot;Fund/Manager/Id\&quot;. (optional)</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (FundProperties)</returns>
        public async System.Threading.Tasks.Task<Lusid.Sdk.Client.ApiResponse<FundProperties>> UpsertFundPropertiesWithHttpInfoAsync(string scope, string code, Dictionary<string, Property> requestBody = default(Dictionary<string, Property>), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'scope' is set
            if (scope == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'scope' when calling FundsApi->UpsertFundProperties");

            // verify the required parameter 'code' is set
            if (code == null)
                throw new Lusid.Sdk.Client.ApiException(400, "Missing required parameter 'code' when calling FundsApi->UpsertFundProperties");


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
            localVarRequestOptions.HeaderParameters.Add("X-LUSID-Sdk-Version", "1.1.381");

            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.PostAsync<FundProperties>("/api/funds/{scope}/{code}/properties/$upsert", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("UpsertFundProperties", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}